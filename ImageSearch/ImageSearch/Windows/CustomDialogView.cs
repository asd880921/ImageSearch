using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ImageSearch.Windows
{
    public class CustomDialogWindow : CustomWindow
    {
        protected override Grid _mainGrid => this._mainGrid;

        public CustomDialogWindow()
        {
            this.Loaded += CustomDialogWindow_Loaded;
        }
       
        private void CustomDialogWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // SizeToContent = WidthAndHeight 和 WindowChrome有黑邊Bug, 在Loading取得真正視窗大小後, 將SizeToContent切回至Manual(手動)
            this.SizeToContent = SizeToContent.Manual;
            //this.Width = (int)MainGrid.ActualWidth; //寬度保持原計算, 否則會出現文字顯示不全
            this.Height = (int)_mainGrid.ActualHeight;

            // 取得主視窗內容
            var mainWindow = Application.Current.MainWindow;
            double mainWindowLeft = mainWindow.Left;
            double mainWindowTop = mainWindow.Top;
            double mainWindowWidth = mainWindow.ActualWidth;
            double mainWindowHeight = mainWindow.ActualHeight;

            // 計算位置，顯示在 主視窗 的正中央
            this.Left = mainWindowLeft + (mainWindowWidth - this.Width) / 2;
            this.Top = mainWindowTop + (mainWindowHeight - this.Height) / 2;
        }
    }
}
