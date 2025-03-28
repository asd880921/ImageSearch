using ImageSearch.Controls;
using ImageSearch.Helpers;
using ImageSearch.Windows;
using System;
using System.Collections.Generic;
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

namespace ImageSearch.Pages
{
    /// <summary>
    /// SettingPage.xaml 的互動邏輯
    /// </summary>
    public partial class SettingPage : Page
    {
        public SettingPage()
        {
            InitializeComponent();

            Themes.SelectedIndex = GetThemeIndex(ConfigHelper.Config.GetTheme);
        }

        private int GetThemeIndex(string theme) => theme switch
        {
            "System" => 0,
            "Light" => 1,
            "Dark" => 2,
            _ => 0 // 預設為 System
        };

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)Themes.SelectedItem;
            string value = item.Content.ToString();
            switch (value)
            {
                case "System":
                    Application.Current.ThemeMode = ThemeMode.System;
                    break;
                case "Light":
                    Application.Current.ThemeMode = ThemeMode.Light;
                    break;
                case "Dark":
                    Application.Current.ThemeMode = ThemeMode.Dark;
                    break;
                default:
                    return;
            }

            ConfigHelper.Config.SetTheme(value);
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog.Show("提示"
                , "應用版本 : V1.0.0" + Environment.NewLine
                + "作者 : TheHon"
                , "關閉", null, null);
        }

        private void UpdateDBButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDBDialog dBDialog = new UpdateDBDialog();
            dBDialog.ShowDialog();
        }
    }
}
