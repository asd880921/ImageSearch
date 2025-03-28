# 卡牌搜尋系統：基於 OpenCV 圖像辨識應用

## 環境需求

- **.NET 9.0 SDK**

## 系統功能

- **搜尋資料夾**  
  用於存放待搜尋的圖像文件。

- **發佈資料夾**  
  圖像比對成功後，結果將自動輸出至此資料夾。

## 資料庫設置

- 所有資料庫均以 **Database_*** 為前綴（例如：Database_Pokemon），路徑在應用目錄底下。
- **Temp 資料夾**  
  通過系統中的 [設定 - 資料庫更新] 功能，選取並更新所需圖像資料庫。  
  更新後，系統將在目錄下生成相應的 **Database_*_Temp** 資料夾，  
  從而減少圖像轉換時間 (比對過程中直接從 Temp 資料夾讀取數據，而非原始資料夾，  
  如果有要新增資料庫圖檔，則需設定在更新一次資料庫)。

## 範例圖片

![Imgur](https://i.imgur.com/D7o7R6R.png)
![Imgur](https://i.imgur.com/jNgaTO7.png)
![Imgur](https://i.imgur.com/OimNdAr.png)

## 操作影片 (Youtube)

[![](https://markdown-videos-api.jorgenkh.no/youtube/w-ODS1XKXTU)](https://youtu.be/w-ODS1XKXTU)
