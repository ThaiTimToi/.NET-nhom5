using System.Windows;

namespace MiniPOS
{
    public partial class PosSettingWindow : Window
    {
        public PosSettingWindow()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Đã lưu cài đặt máy POS.", "Thông báo");
        }
    }
}