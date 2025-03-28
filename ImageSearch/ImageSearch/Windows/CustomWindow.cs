using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shell;
using System.Windows;
using static ImageSearch.Utils.Utils.ParameterTypes;
using System.Windows.Interop;

namespace ImageSearch.Windows
{
    public abstract class CustomWindow : Window
    {
        /// <summary>
        /// 視窗最外層的Grid (傳遞的Grid本身不可設置Margin, 會被覆蓋)
        /// </summary>
        protected abstract Grid _mainGrid { get; }

        /// <summary>
        /// 禁用按鈕
        /// </summary>
        public bool DisableCloseButton { get; set; } = false;

        public CustomWindow()
        {
            UpdateWindowBackground();
            WindowChrome.SetWindowChrome(
                this,
                new WindowChrome
                {
                    CaptionHeight = 42, // 標題欄的高度。這個屬性指定了標題欄的高度（通常用來放置自定義標題欄）。
                    CornerRadius = default,
                    GlassFrameThickness = new Thickness(1), //-1:啟用aero特效, 0:無邊框 1:自定義邊框寬度 (設置1即可, Win11才能保持圓角)
                    ResizeBorderThickness = this.ResizeMode == ResizeMode.NoResize ? default : new Thickness(4),
                    UseAeroCaptionButtons = true
                }
            );

            this.StateChanged += Window_StateChanged;
        }

        private void Window_StateChanged(object? sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                _mainGrid.Margin = new Thickness(8);
            }
            else
            {
                _mainGrid.Margin = default;
            }
        }

        private void UpdateWindowBackground()
        {
            this.SetResourceReference(BackgroundProperty, "WindowBackground");
        }
    }
}
