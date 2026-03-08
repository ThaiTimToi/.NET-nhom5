using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace MiniPOS
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void txtStaffCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]+$");
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string code = txtStaffCode.Text.Trim();
            string staffName = "";

            switch (code)
            {
                case "2033240309":
                    staffName = "Võ Văn Thái";
                    break;
                case "2033240310":
                    staffName = "Thảo";
                    break;
                case "2033240311":
                    staffName = "Trân";
                    break;
                default:
                    MessageBox.Show("Nhân viên không tồn tại.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
            }

            MainWindow main = new MainWindow(code, staffName);
            main.Show();
            Close();
        }
    }
}