using System.Windows;

namespace MiniPOS
{
    public partial class FeatureWindow : Window
    {
        public FeatureWindow()
        {
            InitializeComponent();
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow win = new AddProductWindow();
            win.ShowDialog();
        }

        private void BtnHistory_Click(object sender, RoutedEventArgs e)
        {
            TransactionHistoryWindow win = new TransactionHistoryWindow();
            win.ShowDialog();
        }

        private void BtnPromotion_Click(object sender, RoutedEventArgs e)
        {
            PromotionWindow win = new PromotionWindow();
            win.ShowDialog();
        }

        private void BtnStaff_Click(object sender, RoutedEventArgs e)
        {
            StaffManagementWindow win = new StaffManagementWindow();
            win.ShowDialog();
        }

        private void BtnStock_Click(object sender, RoutedEventArgs e)
        {
            StockWindow win = new StockWindow();
            win.ShowDialog();
        }

        private void BtnRevenue_Click(object sender, RoutedEventArgs e)
        {
            RevenueWindow win = new RevenueWindow();
            win.ShowDialog();
        }

        private void BtnSetting_Click(object sender, RoutedEventArgs e)
        {
            PosSettingWindow win = new PosSettingWindow();
            win.ShowDialog();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}