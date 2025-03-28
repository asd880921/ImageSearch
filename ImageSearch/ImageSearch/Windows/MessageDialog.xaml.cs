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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ImageSearch.Windows
{
    /// <summary>
    /// Dialog.xaml 的互動邏輯
    /// </summary>
    public partial class MessageDialog : CustomDialogWindow
    {
        public DialogResult Result { get; set; } = DialogResult.Close;

        public new enum DialogResult
        {
            Close = -1,     // 關閉 (不正常關閉, 例如ALT + F4)
            Ok,         // 確定
            Cancel,     // 取消
            Other       // 其他
        }

        public MessageDialog(string title, string message, string? okButton, string? cancelButton, string? otherButton)
        {
            InitializeComponent();

            Title = title; // real title
            Titlebar.Title = title; // custom title
            Message.Text = message;

            SetButton(OkButton, OkColumn, okButton);
            SetButton(CancelButton, CancelColumn, cancelButton);
            SetButton(OtherButton, OtherColumn, otherButton);
        }

        public static DialogResult Show(string title, string message, string? okButton, string? cancelButton, string? otherButton)
        {
            return Application.Current.Dispatcher.Invoke(() => 
            {
                MessageDialog dialog = new MessageDialog(title, message, okButton, cancelButton, otherButton);
                dialog.ShowDialog();
                return dialog.Result;
            });
        }

        protected override Grid _mainGrid => this.MainGrid;

        private void SetButton(Button btn, ColumnDefinition col, string? btnName)
        {
            if (btnName == null)
            {
                btn.Visibility = Visibility.Collapsed;
                col.Width = new GridLength(0);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.Name == OkButton.Name)
                {
                    this.Result = DialogResult.Ok;
                }
                else if (btn.Name == CancelButton.Name)
                {
                    this.Result = DialogResult.Cancel;
                }
                else if (btn.Name == OtherButton.Name)
                {
                    this.Result = DialogResult.Other;
                }
            }
            this.Close();
        }
    }
}
