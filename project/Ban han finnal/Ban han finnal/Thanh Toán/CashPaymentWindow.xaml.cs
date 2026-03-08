using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace MiniPOS
{
    public partial class CashPaymentWindow : Window
    {
        private readonly int _total;

        public CashPaymentWindow(int total)
        {
            InitializeComponent();
            _total = total;
            txtTotal.Text = "Tổng tiền: " + string.Format(new CultureInfo("vi-VN"), "{0:N0} đ", _total);
        }

        private int ParseMoney(string input)
        {
            int value;
            int.TryParse(input, out value);
            return value;
        }

        private void txtCash_TextChanged(object sender, TextChangedEventArgs e)
        {
            int cash = ParseMoney(txtCash.Text.Trim());
            int change = cash - _total;

            if (change < 0)
            {
                txtChange.Text = "Tiền dư: 0 đ";
            }
            else
            {
                txtChange.Text = "Tiền dư: " + string.Format(new CultureInfo("vi-VN"), "{0:N0} đ", change);
            }
        }

        private void Denomination_Click(object sender, RoutedEventArgs e)
        {
            string text = (sender as Button).Content.ToString().Replace("k", "");
            int money = int.Parse(text) * 1000;
            txtCash.Text = money.ToString();
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            int cash = ParseMoney(txtCash.Text.Trim());

            if (cash < _total)
            {
                MessageBox.Show("Tiền khách đưa chưa đủ.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show("Thanh toán thành công.\nBạn có muốn in hóa đơn không?", "Hoàn tất", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Đã in hóa đơn.", "Thông báo");
            }

            DialogResult = true;
            Close();
        }
    }
}