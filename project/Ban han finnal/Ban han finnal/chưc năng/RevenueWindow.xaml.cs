using System.Windows;

namespace MiniPOS
{
    public partial class RevenueWindow : Window
    {
        public RevenueWindow()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}