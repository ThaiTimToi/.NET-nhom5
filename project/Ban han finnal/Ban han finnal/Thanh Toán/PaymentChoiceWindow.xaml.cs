using System.Globalization;
using System.Windows;

namespace MiniPOS
{
    public partial class PaymentChoiceWindow : Window
    {
        private readonly int _total;

        public PaymentChoiceWindow(int total)
        {
            InitializeComponent();
            _total = total;
            txtTotal.Text = "Tổng tiền: " + string.Format(new CultureInfo("vi-VN"), "{0:N0} đ", _total);
        }

        private void Cash_Click(object sender, RoutedEventArgs e)
        {
            CashPaymentWindow cash = new CashPaymentWindow(_total);
            bool? result = cash.ShowDialog();

            if (result == true)
            {
                DialogResult = true;
                Close();
            }
        }

        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            TransferPaymentWindow transfer = new TransferPaymentWindow(_total);
            bool? result = transfer.ShowDialog();

            if (result == true)
            {
                DialogResult = true;
                Close();
            }
        }
    }
}