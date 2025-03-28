using OpenCvSharp.Features2D;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Windows.Shell;
using ImageSearch.Pages;
using System.Security.Cryptography;

namespace ImageSearch.Helpers
{
    internal class OpenCVHelper : IDisposable
    {
        private SIFT _sift;
        private BFMatcher _bf;
        private int _matchValue = 10;
        private double _checkValue = 0.75;
        private readonly string _searchPath;
        private readonly string _releasePath;


        private Action<string> _message;
        private string _dbPath, _tempPath, _startTimeStamp;
        private bool _checkRect;

        private OpenCVHelper()
        {
            _sift = SIFT.Create();
            _bf = new BFMatcher(NormTypes.L2, false);
            _searchPath = Utility.searchPath;
            _releasePath = Utility.releasePath;
        }

        public static void UpdateDB(Action<string> message, string dbPath, string tempPath)
        {
            using (OpenCVHelper openCV = new())
            {
                openCV._message = message;
                openCV._dbPath = dbPath;
                openCV._tempPath = tempPath;

                openCV.UpdateDB();
            }
        }

        public static int Run(Action<string> message, string dbPath, string tempPath, bool checkRect, bool expandSearch, string start_timestamp)
        {
            using (OpenCVHelper openCV = new())
            {
                openCV._message = message;
                openCV._dbPath = dbPath;
                openCV._tempPath = tempPath;
                openCV._checkRect = checkRect;
                openCV._startTimeStamp = start_timestamp;

                if (expandSearch)
                    openCV._matchValue = 3;

                return openCV.Run();
            }
        }

        #region UpdateDB
        private void UpdateDB()
        {
            _message($"取得實體資料庫圖片中....");
            var dbData = GetDBImages();
            var dbImages = dbData.images;
            var dbKeypointsList = dbData.keypoints;
            var dbDescriptorsList = dbData.descriptors;
            SaveTempImages(dbImages, dbKeypointsList, dbDescriptorsList);
        }

        //獲取DB所有圖片資料 (包括子資料夾中的圖片)
        private (List<Mat> images, List<KeyPoint[]> keypoints, List<Mat> descriptors) GetDBImages()
        {
            var images = new List<Mat>(); //矩陣Mat : OpenCV 的矩陣物件
            var keypoints = new List<KeyPoint[]>(); //特徵點 keyPoint : 當前圖像中檢測到的資料 => 座標位置（x, y）和其相關資訊（方向、大小等) 以陣列方式進行儲存。
            var descriptors = new List<Mat>(); //描述符descriptor : 當前圖像 keyPoint 的描述內容 => 周圍像素分佈的數值化

            //取出資料庫所有圖片路徑
            var pathImages = Directory.GetFiles(_dbPath, "*.*", SearchOption.AllDirectories)
                                          .Where(s => s.EndsWith(".jpg") || s.EndsWith(".jpeg") || s.EndsWith(".png"));

            int count = 0;
            int EndCount = pathImages.Count();
            foreach (var file in pathImages)
            {
                var img = Cv2.ImRead(file, ImreadModes.Grayscale);
                //Cv2.Resize(img, img, new OpenCvSharp.Size(), imageResize, imageResize);
                KeyPoint[] keypointsDb;
                Mat descriptorsDb = new Mat();
                _sift.DetectAndCompute(img, null, out keypointsDb, descriptorsDb); //取得圖像中的 特徵點 以及 描述符
                if (!img.Empty())
                {
                    images.Add(img);
                    keypoints.Add(keypointsDb);
                    descriptors.Add(descriptorsDb);
                }

                count++;
                _message($"轉檔中 : {count}/{EndCount}");
            }

            //回傳資料庫圖片中 各自的 特徵點陣列 以及 特徵描述符矩陣
            return (images, keypoints, descriptors);
        }

        // 儲存資料庫圖像
        private void SaveTempImages(List<Mat> dbImages, List<KeyPoint[]> dbKeypointsList, List<Mat> dbDescriptorsList)
        {
            // 檢查資料夾是否存在
            if (!Directory.Exists(_tempPath))
            {
                Directory.CreateDirectory(_tempPath); //創建
            }
            else
            {
                // 清空資料夾內容
                foreach (var file in Directory.GetFiles(_tempPath))
                {
                    File.Delete(file);
                }
            }

            _message("更新資料庫數據資料檔中，請稍後...");

            // 保存新的數據
            for (int i = 0; i < dbImages.Count; i++)
            {
                var imageData = new ImageData
                {
                    Image = dbImages[i].ToBytes(),
                    Descriptors = dbDescriptorsList[i].ToBytes(),
                    KeyPoints = dbKeypointsList[i].Select(kp => new SerializableKeyPoint
                    {
                        X = kp.Pt.X,
                        Y = kp.Pt.Y,
                        Size = kp.Size,
                        Angle = kp.Angle,
                        Response = kp.Response,
                        Octave = kp.Octave,
                        ClassId = kp.ClassId
                    }).ToArray()
                };

                string json = JsonSerializer.Serialize(imageData);
                File.WriteAllText(Path.Combine(_tempPath, $"{i}_image.json"), json);

                _message($"更新數據資料 : {i + 1}/{dbImages.Count}");
            }
        }
        #endregion

        #region Run
        private int Run()
        {
            List<Mat> dbImages; //矩陣Mat : OpenCV 的矩陣物件
            List<KeyPoint[]> dbKeypointsList; //特徵點 keyPoint : 當前圖像中檢測到的資料 => 座標位置（x, y）和其相關資訊（方向、大小等) 以陣列方式進行儲存。
            List<Mat> dbDescriptorsList; //描述符descriptor : 當前圖像 keyPoint 的描述內容 => 周圍像素分佈的數值化

            _message("讀取中，請稍後...");

            //載入Temp的圖像資料
            (dbImages, dbKeypointsList, dbDescriptorsList) = LoadTempImages();

            //取得查詢圖像中的 灰階 Mat 物件列表
            var searchFiles = Directory.GetFiles(_searchPath, "*.*")
                           .Where(s => s.EndsWith(".jpg") || s.EndsWith(".jpeg") || s.EndsWith(".png"))
                           .ToList();
            var searchImages = searchFiles.Select(f => Cv2.ImRead(f, ImreadModes.Grayscale)).ToList();
  
            if (!dbImages.Any())
            {
                throw new Exception("資料庫中沒有圖像文件!");
            }
            if (dbImages.Count != dbKeypointsList.Count || dbImages.Count != dbDescriptorsList.Count) //儲存時是將圖片中的Mat,特徵點，描述符儲存到 Index_Image.json (不太可能遇到數量不一致的情況)
            {
                throw new Exception("Temp內容有誤，請重新更新資料庫內容!");
            }
            if (!searchFiles.Any())
            {
                throw new Exception("搜索路徑下沒有圖像文件!");
            }

            _message("開始執行圖像比對!");
            int successCount = 0;
            int nowCount = 0;
            int endCount = searchImages.Count * dbImages.Count;
            foreach (var searchImage in searchImages)
            {
                KeyPoint[] keypointsSearch;
                Mat descriptorsSearch = new Mat();
                _sift.DetectAndCompute(searchImage, null, out keypointsSearch, descriptorsSearch); //用 OpenCV 的 SIFT（尺度不變特徵變換）算法 來檢測圖像中的特徵點並計算其描述符

                for (int idx = 0; idx < dbImages.Count; idx++)
                {
                    nowCount++;
                    _message($"{nowCount}/{endCount} Loading...");
                    var result = GetMatchedImage(keypointsSearch, descriptorsSearch, dbKeypointsList[idx], dbDescriptorsList[idx]); //取得兩張比對圖 各自的 特徵點索引

                    //回傳是否比對成功 (比對成功後需要進行矩形檢查, 檢查是否為卡面)
                    if (result != null && result.HasValue)
                    {
                        //取得矩形座標點 (回傳null則代表非矩形)
                        var dst = GetRectDestination(searchImage, dbImages[idx], result.Value);
                        if (dst != null)
                        {
                            var drawDBImage = DrawLineToImage(dbImages[idx], dst);
                            SaveMatchedImage(drawDBImage, successCount);
                            successCount++;
                        }
                    }
                }
            }

            return successCount;
        }

        // 載入資料庫圖像
        private (List<Mat> dbImages, List<KeyPoint[]> dbKeypointsList, List<Mat> dbDescriptorsList) LoadTempImages()
        {
            var dbImages = new List<Mat>();
            var dbKeypointsList = new List<KeyPoint[]>(); 
            var dbDescriptorsList = new List<Mat>();

            foreach (var file in Directory.GetFiles(_tempPath, "*.json"))
            {
                string json = File.ReadAllText(file);
                var imageData = JsonSerializer.Deserialize<ImageData>(json);

                // 將圖像Byte 解碼為 Mat對象
                Mat image = Cv2.ImDecode(imageData.Image, ImreadModes.Color);
                dbImages.Add(image);

                // 將描述符 解碼為 Mat對象
                Mat descriptors = new Mat();
                Cv2.ImDecode(imageData.Descriptors, ImreadModes.Grayscale).ConvertTo(descriptors, MatType.CV_32F);
                dbDescriptorsList.Add(descriptors);

                // 將特徵點從Json物件 轉換為 KeyPoint陣列
                var keypoints = new List<KeyPoint>();
                foreach (var kp in imageData.KeyPoints)
                {
                    keypoints.Add(new KeyPoint(kp.X, kp.Y, kp.Size, kp.Angle, kp.Response, kp.Octave, kp.ClassId));
                }
                dbKeypointsList.Add(keypoints.ToArray());
            }
            return (dbImages, dbKeypointsList, dbDescriptorsList);
        }

        // 圖像匹配搜尋 (回傳 兩張比對圖 各自的 特徵點索引)
        private (Point2f[], Point2f[])? GetMatchedImage(KeyPoint[] keypointsSearch, Mat descriptorsSearch, KeyPoint[] keypointsDb, Mat descriptorsDb)
        {
            //KNN 匹配(近鄰演算法匹配) : 對搜尋圖像中的特徵點, 描述符 進行KNN匹配(K-最近鄰演算法)，k=2 表示每個描述符返回兩個最佳匹配。
            var matches = _bf.KnnMatch(descriptorsSearch, descriptorsDb, 2);

            //取得良好匹配 (使用 比率測試 Ratio Test 過濾不可靠的特徵匹配)
            var goodMatches = matches
                .Where(m => m.Length == 2 && m[0].Distance < _checkValue * m[1].Distance) //檢查是否有兩個匹配(最近鄰 和 次近鄰), 且如果距離小於閥值 (checkValue) 則代表該匹配是可靠的。
                .Select(m => m[0])
                .ToList();

            //檢查良好匹配數量是否足夠 (越多代表該圖片匹配程度越完整, 以 matchValue 作為閥值)
            if (goodMatches.Count < _matchValue)
            {
                return null;
            }

            var searchPts = goodMatches.Select(m => keypointsSearch[m.QueryIdx].Pt).ToArray(); //查詢圖像的特徵點索引
            var dbPts = goodMatches.Select(m => keypointsDb[m.TrainIdx].Pt).ToArray(); //資料庫圖像的特徵點索引

            return (searchPts, dbPts);
        }

        // 取得透視變換座標 (將四個座標點 映射到圖像中的座標位置)
        private Point2f[] GetRectDestination(Mat searchImage, Mat dbImage, (Point2f[], Point2f[]) args)
        {
            #region 檢查是否為矩形
            var searchPts = args.Item1;
            var dbPts = args.Item2;
             
            //計算
            Mat M = Cv2.FindHomography(InputArray.Create(searchPts), InputArray.Create(dbPts), HomographyMethods.Ransac, 5);

            int h = searchImage.Height;
            int w = searchImage.Width;

            //左上0, 0
            //左下0, h-1 (索引是從0開始), 總高度需 -1)
            //右上w-1, 0 (索引是從0開始), 總寬度需 -1)
            //右下w-1, h-1 (索引是從0開始), 總高/寬度需 -1)
            Point2f[] pts = { new Point2f(0, 0), new Point2f(0, h - 1), new Point2f(w - 1, h - 1), new Point2f(w - 1, 0) };

            //透視變換 (將四個座標點 映射到圖像中的座標位置)
            Point2f[] dst = Cv2.PerspectiveTransform(pts, M);

            // 檢查四邊形是否為矩形 (checkRect 為 false 則跳過該檢驗)
            if (_checkRect && !CheckIfRectangle(dst))
            {
                return null;
            }
            #endregion

            #region 計算面積 (過濾掉過大 以及 過小的區域) - 目前棄用
            //// 計算圖像的總面積
            //double totalArea = dbImage.Width * dbImage.Height;

            //// 設定最小和最大面積閾值（以圖像面積的百分比為基準）
            //double minAreaPercentage = 0.01; // 最小面積為圖像面積的1%
            //double maxAreaPercentage = 0.5;  // 最大面積為圖像面積的50%

            //// 計算最小和最大面積
            //double minArea = totalArea * minAreaPercentage;
            //double maxArea = totalArea * maxAreaPercentage;

            //// 面積過濾
            //double area = Cv2.ContourArea(dst);
            //if (area < minArea || area > maxArea)
            //{
            //    return null;
            //}
            #endregion

            return dst;
        }

        // 檢查點是否形成矩形的方法
        private bool CheckIfRectangle(Point2f[] points)
        {
            if (points.Length != 4)
            {
                return false;
            }

            // 計算向量
            var v1 = new Point2f(points[1].X - points[0].X, points[1].Y - points[0].Y); // 左上 -> 左下
            var v2 = new Point2f(points[2].X - points[1].X, points[2].Y - points[1].Y); // 左下 -> 右下
            var v3 = new Point2f(points[3].X - points[2].X, points[3].Y - points[2].Y); // 右下 -> 右上
            var v4 = new Point2f(points[0].X - points[3].X, points[0].Y - points[3].Y); // 右上 -> 左上

            // 計算向量的點積
            double dotProduct1 = v1.X * v2.X + v1.Y * v2.Y; // 左上 -> 左下 與 左下 -> 右下
            double dotProduct2 = v2.X * v3.X + v2.Y * v3.Y; // 左下 -> 右下 與 右下 -> 右上
            double dotProduct3 = v3.X * v4.X + v3.Y * v4.Y; // 右下 -> 右上 與 右上 -> 左上
            double dotProduct4 = v4.X * v1.X + v4.Y * v1.Y; // 右上 -> 左上 與 左上 -> 左下

            // 計算向量的長度
            double length1 = Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y);
            double length2 = Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y);
            double length3 = Math.Sqrt(v3.X * v3.X + v3.Y * v3.Y);
            double length4 = Math.Sqrt(v4.X * v4.X + v4.Y * v4.Y);

            // 計算夾角的餘弦值
            double cosAngle1 = dotProduct1 / (length1 * length2);
            double cosAngle2 = dotProduct2 / (length2 * length3);
            double cosAngle3 = dotProduct3 / (length3 * length4);
            double cosAngle4 = dotProduct4 / (length4 * length1);

            // 計算夾角（弧度）
            double angle1 = Math.Acos(cosAngle1) * (180.0 / Math.PI);
            double angle2 = Math.Acos(cosAngle2) * (180.0 / Math.PI);
            double angle3 = Math.Acos(cosAngle3) * (180.0 / Math.PI);
            double angle4 = Math.Acos(cosAngle4) * (180.0 / Math.PI);

            // 檢查所有夾角是否接近90度
            double tolerance = 10.0; // 容忍誤差範圍
            return Math.Abs(angle1 - 90) < tolerance &&
                   Math.Abs(angle2 - 90) < tolerance &&
                   Math.Abs(angle3 - 90) < tolerance &&
                   Math.Abs(angle4 - 90) < tolerance;

            ////取得四邊形點到點之間距離
            //double left = Distance(points[0], points[1]); //左邊 (左上左下)
            //double down = Distance(points[1], points[2]); //下面 (左下右下)
            //double right = Distance(points[2], points[3]); //右邊 (右下右上)
            //double top = Distance(points[3], points[0]); //上面 (右上左上)
            ////取得對角線距離
            //double diagonal1 = Distance(points[0], points[2]); //左上 到 右下
            //double diagonal2 = Distance(points[1], points[3]); //左下 到 右上

            //return Math.Abs(left - right) < 10  //左右長度相減 取出絕對值 誤差長度不可超過10
            //    && Math.Abs(down - top) < 10 //上下長度相減 取出絕對值 誤差長度不可超過10
            //    && Math.Abs(diagonal1 - diagonal2) < 10; //對角線 取出絕對值 誤差長度不可超過10
        }

        // 計算兩點之間的距離
        private double Distance(Point2f p1, Point2f p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        //取得畫線後的圖像
        private Mat DrawLineToImage(Mat dbImage, Point2f[] dst)
        {
            //建立容器
            Mat matchedImage = new Mat();
            // 如果 dbImage 是灰階圖像 則需轉換回 BGR 格式 (彩色圖像)
            if (dbImage.Channels() == 1)
            {
                Cv2.CvtColor(dbImage, matchedImage, ColorConversionCodes.GRAY2BGR);
            }
            else
            {
                matchedImage = dbImage;
            }

            //在matchedImage中繪製線條
            Cv2.Polylines(matchedImage // 目標圖像容器
                , new[] { dst.Select(p => new OpenCvSharp.Point(p.X, p.Y)).ToArray() } // 矩形座標點
                , true // 是否閉合多邊形
                , Scalar.Red // 顏色
                , 5); // 線寬

            return matchedImage;
        }

        // 保存圖像結果
        private void SaveMatchedImage(Mat matchedDBImage, int count)
        {
            if (!Directory.Exists(_releasePath))
            {
                Directory.CreateDirectory(_releasePath);
            }

            string imagePath = Path.Combine(_releasePath, _startTimeStamp);
            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }

            string savePath = Path.Combine(imagePath, $"{count}.png");
            Cv2.ImWrite(savePath, matchedDBImage);
        }
        #endregion

        public void Dispose()
        {
            _sift?.Dispose();
            _bf?.Dispose();
            GC.SuppressFinalize(this);
        }

        private class ImageData
        {
            public byte[] Image { get; set; }
            public SerializableKeyPoint[] KeyPoints { get; set; }
            public byte[] Descriptors { get; set; }
        }

        /// <summary>
        /// (序列化物件) 特徵點陣列內容
        /// </summary>
        private struct SerializableKeyPoint
        {
            public float X { get; set; }
            public float Y { get; set; }
            public float Size { get; set; }
            public float Angle { get; set; }
            public float Response { get; set; }
            public int Octave { get; set; }
            public int ClassId { get; set; }
        }
    }
}
