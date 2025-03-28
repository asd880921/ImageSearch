using ImageSearch.Helpers;
using ImageSearch.Windows;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;

namespace ImageSearch.Pages
{
    /// <summary>
    /// SearchPage.xaml 的互動邏輯
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();

            SetTeamComboBoxData();

            CheckRect.IsChecked = ConfigHelper.Config.GetCheckRect;
            ExpandSearch.IsChecked = ConfigHelper.Config.GetExpandSearch;

            CheckRect.Click += CheckRect_Click;
            ExpandSearch.Click += ExpandSearch_Click;
        }

        private void SetTeamComboBoxData()
        {
            string[] folders = Directory.GetDirectories(Directory.GetCurrentDirectory())
                            .Select(d => System.IO.Path.GetFileName(d))
                            .Where(d => d.Contains(Utility.dbPath) && !d.Contains(Utility.tempPath))
                            .Select(d => d.Replace(Utility.dbPath, ""))
                            .ToArray();

            Team_ComboBox.Items.Clear();
            if (folders != null && folders.Length > 0)
            {
                Team_ComboBox.ItemsSource = folders;
                Team_ComboBox.SelectedIndex = 0;
            }
        }

        private void CheckRect_Click(object sender, RoutedEventArgs e)
        {
            if (CheckRect.IsChecked == false)
            {
                MessageDialog.DialogResult result = MessageDialog.Show("提示", "檢查矩形 建議「開啟」，您確定要關閉嗎?", "確定", "取消", null);
                CheckRect.IsChecked = result == MessageDialog.DialogResult.Cancel;
            }

            ConfigHelper.Config.SetCheckRect(CheckRect.IsChecked ?? false);
        }

        private void ExpandSearch_Click(object sender, RoutedEventArgs e)
        {
            if (ExpandSearch.IsChecked == true)
            {
                MessageDialog.DialogResult result = MessageDialog.Show("提示", "擴大搜尋 建議「關閉」，您確定要開啟嗎?", "確定", "取消", null);
                ExpandSearch.IsChecked = result == MessageDialog.DialogResult.Ok;
            }

            ConfigHelper.Config.SetExpandSearch(ExpandSearch.IsChecked ?? false);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e) => OpenDirectory(Utility.searchPath);

        private void PublishButton_Click(object sender, RoutedEventArgs e) => OpenDirectory(Utility.releasePath);

        private void StartSearchButton_Click(object sender, RoutedEventArgs e)
        {
            bool _checkRect = this.CheckRect.IsChecked ?? true;
            bool _expandSearch = this.ExpandSearch.IsChecked ?? false;

            string _dbPath = Utility.dbPath + Team_ComboBox.Text.ToString();
            DateTime startTime = DateTime.Now;
            string str_startTime = startTime.ToString("yyyyMMddHHmmssfff");
            FreezeControl(true);
            new Thread(() =>
            {
                try
                {
                    int successCount = OpenCVHelper.Run(
                        WriteLog //委派回寫Log
                        , _dbPath //DB路徑
                        , _dbPath + Utility.tempPath //TEMP路徑
                        , _checkRect //檢查矩形
                        , _expandSearch //擴大搜尋
                        , str_startTime); //開始時間

                    // 計算耗時
                    DateTime endTime = DateTime.Now;
                    TimeSpan duration = endTime - startTime;
                    string elapsedTime = $"{duration.Minutes} 分 {duration.Seconds} 秒";
                    WriteLog($"耗時 : {elapsedTime}"); // 顯示耗時訊息

                    //成功訊息
                    string msg = $"成功匹配{successCount}張模型, 請至Release資料夾查看!";
                    WriteLog("=>" + msg);
                    MessageDialog.Show("提示", msg, "確定", null, null);
                    
                    //開啟資料夾
                    OpenDirectory(System.IO.Path.Combine(Utility.releasePath, str_startTime));
                }
                catch (Exception ex)
                {
                    WriteLog("=>" + ex.Message);
                }
                finally
                {
                    FreezeControl(false);
                }
            }).Start();
        }

        private void FreezeControl(bool isFreeze)
        {
            try
            {
                Dispatcher.Invoke(() => Application.Current.MainWindow.IsEnabled = !isFreeze);
            }
            catch (Exception e)
            {
                Environment.Exit(1);
            }
        }

        private void WriteLog(string message)
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    ContentInput.Text += message + "\r\n";
                    ContentInput.SelectionStart = ContentInput.Text.Length;
                    ContentInput.ScrollToEnd();
                });
            }
            catch (Exception e)
            {
                Environment.Exit(1);
            }
        }

        private void OpenDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = "explorer.exe"; // 使用 Windows 檔案總管
            prc.StartInfo.Arguments = path; // 資料夾的路徑
            prc.StartInfo.UseShellExecute = true; // 使用外殼執行
            prc.Start();
            prc.Close();
            prc.Dispose();
        }
    }
}
