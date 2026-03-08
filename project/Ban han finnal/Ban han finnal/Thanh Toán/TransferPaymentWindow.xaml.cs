using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MiniPOS
{
    public partial class TransferPaymentWindow : Window
    {
        private readonly int _total;

        public TransferPaymentWindow(int total)
        {
            InitializeComponent();
            _total = total;
            txtTotal.Text = "Tổng tiền: " + string.Format(new CultureInfo("vi-VN"), "{0:N0} đ", _total);
        }

        private async void Pay_Click(object sender, RoutedEventArgs e)
        {
            btnTransfer.IsEnabled = false;
            cmbMethod.IsEnabled = false;

            ComboBoxItem item = cmbMethod.SelectedItem as ComboBoxItem;
            string method = item != null ? item.Content.ToString() : "Momo";

            txtStatus.Text = "Đã tạo mã thanh toán qua " + method + ". Đang chờ xác nhận...";
            progressBar.Value = 0;

            for (int i = 1; i <= 10; i++)
            {
                await Task.Delay(1000);
                progressBar.Value = i;
            }

            txtStatus.Text = "Chuyển khoản thành công.";

            var result = MessageBox.Show("Chuyển khoản thành công.\nBạn có muốn in hóa đơn không?", "Hoàn tất", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Đã in hóa đơn.", "Thông báo");
            }

            DialogResult = true;
            Close();
        }
    }
}