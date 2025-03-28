using ImageSearch.Pages;
using ImageSearch.Windows;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : CustomWindow
    {
        private Type? nowPageType;
        private double menuWidth;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        protected override Grid _mainGrid => this.MainGrid;
        public void ProcessBar(bool isShow)
        {
            ProcessBarView.Visibility = isShow ? Visibility.Visible : Visibility.Collapsed;
        }



        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            menuWidth = Menu.ActualWidth;
            Search.IsSelected = true; //預設選取Search
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation;
            if (Menu.Visibility == Visibility.Visible)
            {
                animation = new DoubleAnimation()
                {
                    Duration = new Duration(TimeSpan.FromMilliseconds(250)),
                    From = menuWidth,
                    To = 0,
                };

                Storyboard.SetTarget(animation, Menu); //設置動畫目標物件
                Storyboard.SetTargetProperty(animation, new PropertyPath("Width")); //設定動畫目標物件元素

                // 開始執行動畫
                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(animation); // 將動畫加入到 Storyboard 的 Children
                storyboard.Completed += (s, e) => Menu.Visibility = Visibility.Collapsed; //動畫完成後 隱藏物件
                storyboard.Begin();
            }
            else
            {
                animation = new DoubleAnimation()
                {
                    Duration = new Duration(TimeSpan.FromMilliseconds(250)),
                    From = 0,
                    To = menuWidth,
                };

                Storyboard.SetTarget(animation, Menu); //設置動畫目標物件
                Storyboard.SetTargetProperty(animation, new PropertyPath("Width")); //設定動畫目標物件元素

                // 開始執行動畫
                Menu.Visibility = Visibility.Visible; //動畫開始前 顯示物件
                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(animation); // 將動畫加入到 Storyboard 的 Children
                storyboard.Begin();
            }
        }

        private void MenuList_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            // 獲取選中的項目
            var selectedItem = MenuList.SelectedItem as TreeViewItem;

            //搜尋
            if (selectedItem == Search)
            {
                NavigatePage(typeof(SearchPage));
                return;
            }
        }

        private void NavigatePage(Type pageType)
        {
            if (nowPageType == pageType)
                return;

            nowPageType = pageType;
            PageContent.Navigate(Activator.CreateInstance(nowPageType)); //反射創建Page
        }

        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            //設定不是TreeViewItem, 導向設定頁面時,需將item 選取清除
            var selectedItem = MenuList.SelectedItem as TreeViewItem;
            if (selectedItem != null)
                selectedItem.IsSelected = false;

            NavigatePage(typeof(SettingPage));
        }
    }
}