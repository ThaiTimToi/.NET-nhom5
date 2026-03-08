using System.Windows;

namespace MiniPOS
{
    public partial class PromotionWindow : Window
    {
        public PromotionWindow()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}