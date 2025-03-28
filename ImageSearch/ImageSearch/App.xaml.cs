using ImageSearch.Helpers;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ImageSearch
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ConfigHelper.Init(); //初始化

            switch (ConfigHelper.Config.GetTheme)
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
            }

            //啟動主頁
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }

}
