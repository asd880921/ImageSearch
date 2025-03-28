using ImageSearch.Helpers;
using ImageSearch.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageSearch.Controls
{
    /// <summary>
    /// CustomTitleBar.xaml 的互動邏輯
    /// </summary>
    public partial class CustomTitleBar : UserControl
    {
        public string Title { get; set; } = string.Empty;
        public int TitleSize { get; set; } = 14;
        public FontWeight TitleWeight { get; set; } = FontWeights.Normal;

        public ImageSource? Icon { get; set; } = null;
        public int IconSize { get; set; } = 24;


        public CustomTitleBar()
        {
            InitializeComponent();

            ////直接隱藏(自訂義工具列Button (使用原生))
            //MinimizeButton.Visibility = Visibility.Collapsed;
            //MaximizeButton.Visibility= Visibility.Collapsed;
            //CloseButton.Visibility = Visibility.Collapsed;

            this.Loaded += CustomTitleBar_Loaded;
        }

        //設計介面
        private void CustomTitleBar_Loaded(object sender, RoutedEventArgs e)
        {
            //在設計模式下, 不執行該區塊邏輯
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                CustomWindow window = (CustomWindow)CustomWindow.GetWindow(this);

                if (window.ResizeMode == ResizeMode.NoResize)
                {
                    MinimizeButton.Visibility = Visibility.Collapsed;
                    MaximizeButton.Visibility = Visibility.Collapsed;
                }

                if (window.DisableCloseButton)
                {
                    CloseButton.Visibility = Visibility.Collapsed;

                    //call win32 API Disable Button.
                    var hwnd = new WindowInteropHelper(window).Handle;
                    IntPtr hMenu = Utility.GetSystemMenu(hwnd, 0);
                    Utility.RemoveMenu(hMenu, Utility.SC_CLOSE, Utility.MF_BYCOMMAND);
                }
            }

            //標題
            TitleText.Text = Title;
            TitleText.FontSize = TitleSize;
            TitleText.FontWeight = TitleWeight;

            //圖示
            if (Icon != null)
            {
                TitleIcon.Visibility = Visibility.Visible;
                TitleIcon.Source = Icon;
                TitleIcon.Width = IconSize;
            }
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.WindowState = WindowState.Minimized;
        }

        private void MaximizeWindow(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window.WindowState == WindowState.Maximized)
            {
                window.WindowState = WindowState.Normal;
                MaximizeIcon.Text = "\uE922";
            }
            else
            {
                window.WindowState = WindowState.Maximized;
                MaximizeIcon.Text = "\uE923";
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
