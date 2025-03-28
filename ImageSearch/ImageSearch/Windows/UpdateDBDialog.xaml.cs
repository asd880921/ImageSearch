using ImageSearch.Helpers;
using ImageSearch.Pages;
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
using System.Windows.Shapes;
using System.Windows.Shell;

namespace ImageSearch.Windows
{
    /// <summary>
    /// UpdateDBDialog.xaml 的互動邏輯
    /// </summary>
    public partial class UpdateDBDialog : CustomDialogWindow
    {
        public UpdateDBDialog()
        {
            InitializeComponent();

            string[] folders = Directory.GetDirectories(Directory.GetCurrentDirectory())
                            .Select(d => System.IO.Path.GetFileName(d))
                            .Where(d => d.Contains(Utility.dbPath) && !d.Contains(Utility.tempPath))
                            .Select(d => d.Replace(Utility.dbPath, ""))
                            .ToArray();

            if (folders != null && folders.Length > 0)
            {
                foreach (var item in folders)
                {
                    CheckBox checkBox = new CheckBox
                    {
                        Content = item
                    };

                    CheckBoxPanel.Children.Add(checkBox);
                }
            }
        }

        protected override Grid _mainGrid => this.MainGrid;


        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var teams = CheckBoxPanel.Children
                                .OfType<CheckBox>()
                                .Where(cb => cb.IsChecked == true)
                                .Select(cb => cb.Content?.ToString())
                                .ToList();

            if (teams == null || teams.Count == 0)
            {
                MessageDialog.Show("提示","請選取需要更新的資料庫!" ,"關閉", null, null);
                return;
            }

            //開始更新資料庫
            Hashtable hashTable = new Hashtable();
            string _path = string.Empty;
            foreach (var item in teams)
            {
                _path = Utility.dbPath + item.ToString();
                hashTable.Add(_path, _path + Utility.tempPath);
            }

            UpdateDB(hashTable);
        }

        private void UpdateDB(Hashtable hashTable)
        {
            DateTime startTime = DateTime.Now;
            string str_startTime = startTime.ToString("yyyyMMddHHmmssfff");
            FreezeControl(true);
            new Thread(() =>
            {
                try
                {  
                    foreach (DictionaryEntry entry in hashTable)
                    {
                        OpenCVHelper.UpdateDB(WriteLog, entry.Key.ToString(), entry.Value.ToString());
                    }

                    // 計算耗時
                    DateTime endTime = DateTime.Now;
                    TimeSpan duration = endTime - startTime;
                    string elapsedTime = $"{duration.Minutes} 分 {duration.Seconds} 秒";
                    WriteLog($"耗時 : {elapsedTime}"); // 顯示耗時訊息
                    WriteLog("=>" + "更新成功!");
                    MessageDialog.Show("提示", "更新成功!", "確定", null, null);
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

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
