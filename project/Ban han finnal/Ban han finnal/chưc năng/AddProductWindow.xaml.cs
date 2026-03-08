using System.Windows;
using System.Windows.Controls;

namespace MiniPOS
{
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo");
                return;
            }

            ComboBoxItem item = cmbCategory.SelectedItem as ComboBoxItem;
            string category = item != null ? item.Content.ToString() : "";

            MessageBox.Show(
                "Đã thêm hàng thành công.\nTên: " + txtName.Text +
                "\nLoại: " + category +
                "\nGiá: " + txtPrice.Text,
                "Thông báo");

            txtName.Clear();
            txtPrice.Clear();
            cmbCategory.SelectedIndex = 0;
        }
    }
}