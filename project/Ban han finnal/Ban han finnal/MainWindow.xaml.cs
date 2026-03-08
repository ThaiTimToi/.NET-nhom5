using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MiniPOS
{
    public partial class MainWindow : Window
    {
        private readonly string _staffCode;
        private readonly string _staffName;

        private ObservableCollection<Product> _allProducts = new ObservableCollection<Product>();
        private ObservableCollection<CartItem> _cart = new ObservableCollection<CartItem>();
        private string _currentCategory = "";

        public MainWindow(string staffCode, string staffName)
        {
            InitializeComponent();

            _staffCode = staffCode;
            _staffName = staffName;

            txtStaffInfo.Text = "Nhân viên: " + _staffName + " | MSNV: " + _staffCode;

            LoadProducts();
            RefreshCart();
        }
        private void btnFeature_Click(object sender, RoutedEventArgs e)
        {
            FeatureWindow feature = new FeatureWindow();
            feature.ShowDialog();
        }
        public class Product
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public int PriceM { get; set; }
            public int PriceL { get; set; }
            public bool HasSize { get; set; }
        }

        public class CartItem
        {
            public string Name { get; set; }
            public string Size { get; set; }
            public int UnitPrice { get; set; }
            public int Qty { get; set; }

            public string DisplayName
            {
                get
                {
                    return string.IsNullOrWhiteSpace(Size) ? Name : Name + " (Size " + Size + ")";
                }
            }

            public string PriceText
            {
                get { return FormatVND(UnitPrice); }
            }

            public string TotalText
            {
                get { return FormatVND(UnitPrice * Qty); }
            }

            public static string FormatVND(int amount)
            {
                return string.Format(new CultureInfo("vi-VN"), "{0:N0} đ", amount);
            }
        }

        private static string FormatVND(int amount)
        {
            return string.Format(new CultureInfo("vi-VN"), "{0:N0} đ", amount);
        }

        private void LoadProducts()
        {
            string[] drinks =
            {
                "Trà chanh","Trà tắc","Trà đào","Trà vải","Trà sữa thái xanh","Trà sữa thái đỏ",
                "Trà sữa matcha","Trà sữa chocolate","Trà sữa oreo","Trà sữa caramel","Trà sữa dâu",
                "Trà sữa bạc hà","Trà sữa khoai môn","Trà sữa dừa","Trà sữa hạt dẻ","Trà sữa kem cheese",
                "Trà sữa pudding","Trà sữa trân châu","Trà sữa hoàng kim","Trà sữa macchiato",
                "Soda chanh","Soda dâu","Soda việt quất","Soda bạc hà","Nước cam","Nước chanh",
                "Nước ép táo","Nước ép dứa","Nước ép dưa hấu","Nước ép xoài","Trà ổi hồng","Trà sen",
                "Trà kiwi","Trà dâu tằm","Trà me"
            };

            foreach (string item in drinks)
            {
                _allProducts.Add(new Product
                {
                    Name = item,
                    Category = "Drink",
                    PriceM = 18000,
                    PriceL = 25000,
                    HasSize = true
                });
            }

            string[] cakes =
            {
                "Bánh socola","Bánh milk","Bánh phô mai","Bánh tiramisu","Bánh bông lan trứng muối",
                "Bánh su kem","Bánh mousse dâu","Bánh mousse xoài","Bánh brownie","Bánh cupcake",
                "Bánh red velvet","Bánh matcha","Bánh flan","Bánh donut","Bánh waffle","Bánh pancake",
                "Bánh kem bơ","Bánh kem dâu","Bánh kem socola","Bánh kem oreo","Bánh caramel",
                "Bánh kem sầu riêng","Bánh kem xoài","Bánh kem trà xanh","Bánh kem vanilla",
                "Bánh kem tiramisu","Bánh cheesecake","Bánh cheesecake dâu","Bánh cheesecake chanh dây",
                "Bánh cheesecake việt quất","Bánh bông lan cuộn","Bánh sữa chua","Bánh táo","Bánh chuối"
            };

            foreach (string item in cakes)
            {
                _allProducts.Add(new Product
                {
                    Name = item,
                    Category = "Cake",
                    PriceM = 22000,
                    PriceL = 22000,
                    HasSize = false
                });
            }

            string[] snacks =
            {
                "Snack khoai tây","Snack rong biển","Snack bắp","Snack cay","Snack phô mai","Snack hành",
                "Snack BBQ","Snack pizza","Snack tôm","Snack cua","Snack phồng tôm","Snack khoai môn",
                "Snack rong nho","Snack kim chi","Snack vị bò","Snack gà cay","Snack mật ong","Snack bơ tỏi",
                "Snack nấm","Snack hải sản","Snack rong biển mè","Snack bắp ngọt","Snack bò nướng"
            };

            foreach (string item in snacks)
            {
                _allProducts.Add(new Product
                {
                    Name = item,
                    Category = "Snack",
                    PriceM = 12000,
                    PriceL = 12000,
                    HasSize = false
                });
            }

            string[] noodles =
            {
                "Hảo Hảo tôm chua cay","Hảo Hảo sa tế","Omachi bò hầm","Omachi sườn","Omachi kim chi",
                "Gấu đỏ","Kokomi","3 Miền","Miliket","Indomie","Samyang","Cung Đình lẩu tôm",
                "Cung Đình bò hầm","Mì ly Hảo Hảo","Mì ly Omachi","Mì ly Kokomi","Mì xào khô Indomie",
                "Mì cay hải sản","Mì cay bò","Mì trộn trứng muối","Mì chay","Mì bò cay","Mì gà nấm"
            };

            foreach (string item in noodles)
            {
                _allProducts.Add(new Product
                {
                    Name = item,
                    Category = "Noodle",
                    PriceM = 10000,
                    PriceL = 10000,
                    HasSize = false
                });
            }

            string[] coffees =
            {
                "Cà phê đen","Cà phê sữa","Bạc xỉu","Cà phê muối","Latte","Cappuccino","Mocha","Americano",
                "Espresso","Cold Brew","Cà phê dừa","Cà phê kem trứng","Cà phê caramel","Cà phê hazelnut",
                "Cà phê vanilla","Cà phê chocolate","Cà phê sữa đá","Cà phê bạc hà"
            };

            foreach (string item in coffees)
            {
                _allProducts.Add(new Product
                {
                    Name = item,
                    Category = "Coffee",
                    PriceM = 20000,
                    PriceL = 28000,
                    HasSize = true
                });
            }
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            _currentCategory = btn.Tag.ToString();
            txtCategoryTitle.Text = "Danh mục: " + btn.Content.ToString();
            ShowProducts();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowProducts();
        }

        private void ShowProducts()
        {
            ProductPanel.Children.Clear();

            var query = _allProducts.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(_currentCategory))
            {
                query = query.Where(p => p.Category == _currentCategory);
            }

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                string keyword = txtSearch.Text.Trim().ToLower();
                query = query.Where(p => p.Name.ToLower().Contains(keyword));
            }

            var products = query.ToList();

            txtProductCount.Text = "Số lượng sản phẩm: " + products.Count;

            foreach (var product in products)
            {
                Border card = new Border();
                card.Width = 205;
                card.Height = 175;
                card.Margin = new Thickness(8);
                card.CornerRadius = new CornerRadius(14);
                card.Background = Brushes.White;
                card.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F2C5C5"));
                card.BorderThickness = new Thickness(1.2);

                StackPanel panel = new StackPanel();
                panel.Margin = new Thickness(12);

                TextBlock txtName = new TextBlock();
                txtName.Text = product.Name;
                txtName.FontWeight = FontWeights.Bold;
                txtName.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B71C1C"));
                txtName.TextWrapping = TextWrapping.Wrap;
                txtName.Height = 42;

                TextBlock txtPrice = new TextBlock();
                txtPrice.Margin = new Thickness(0, 10, 0, 10);
                txtPrice.FontSize = 13;
                txtPrice.Foreground = Brushes.Black;
                txtPrice.Text = product.HasSize
                    ? "Giá M: " + FormatVND(product.PriceM) + "\nGiá L: " + FormatVND(product.PriceL)
                    : "Giá: " + FormatVND(product.PriceM);

                Button btnM = new Button();
                btnM.Height = 30;
                btnM.Margin = new Thickness(0, 0, 0, 6);
                btnM.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D32F2F"));
                btnM.Foreground = Brushes.White;
                btnM.FontWeight = FontWeights.Bold;
                btnM.BorderThickness = new Thickness(0);
                btnM.Tag = product;
                btnM.Content = product.HasSize ? "Thêm Size M" : "Thêm vào giỏ";
                btnM.Click += AddM_Click;

                panel.Children.Add(txtName);
                panel.Children.Add(txtPrice);
                panel.Children.Add(btnM);

                if (product.HasSize)
                {
                    Button btnL = new Button();
                    btnL.Height = 30;
                    btnL.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EF5350"));
                    btnL.Foreground = Brushes.White;
                    btnL.FontWeight = FontWeights.Bold;
                    btnL.BorderThickness = new Thickness(0);
                    btnL.Tag = product;
                    btnL.Content = "Thêm Size L";
                    btnL.Click += AddL_Click;
                    panel.Children.Add(btnL);
                }

                card.Child = panel;
                ProductPanel.Children.Add(card);
            }
        }

        private void AddM_Click(object sender, RoutedEventArgs e)
        {
            Product product = (sender as Button).Tag as Product;
            AddToCart(product, product.HasSize ? "M" : "", product.PriceM);
        }

        private void AddL_Click(object sender, RoutedEventArgs e)
        {
            Product product = (sender as Button).Tag as Product;
            AddToCart(product, "L", product.PriceL);
        }

        private void AddToCart(Product product, string size, int price)
        {
            var existing = _cart.FirstOrDefault(x => x.Name == product.Name && x.Size == size);

            if (existing != null)
            {
                existing.Qty++;
            }
            else
            {
                _cart.Add(new CartItem
                {
                    Name = product.Name,
                    Size = size,
                    UnitPrice = price,
                    Qty = 1
                });
            }

            RefreshCart();
        }

        private void RefreshCart()
        {
            lvCart.ItemsSource = null;
            lvCart.ItemsSource = _cart;

            int total = _cart.Sum(x => x.UnitPrice * x.Qty);
            int itemCount = _cart.Sum(x => x.Qty);

            txtItemCount.Text = "Số món: " + itemCount;
            txtTotal.Text = "Tổng tiền: " + FormatVND(total);
        }

        private CartItem GetSelectedCartItem()
        {
            return lvCart.SelectedItem as CartItem;
        }

        private void btnIncrease_Click(object sender, RoutedEventArgs e)
        {
            var item = GetSelectedCartItem();
            if (item == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trong giỏ hàng.", "Thông báo");
                return;
            }

            item.Qty++;
            RefreshCart();
        }

        private void btnDecrease_Click(object sender, RoutedEventArgs e)
        {
            var item = GetSelectedCartItem();
            if (item == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trong giỏ hàng.", "Thông báo");
                return;
            }

            item.Qty--;

            if (item.Qty <= 0)
            {
                _cart.Remove(item);
            }

            RefreshCart();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            var item = GetSelectedCartItem();
            if (item == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.", "Thông báo");
                return;
            }

            _cart.Remove(item);
            RefreshCart();
        }

        private void btnClearCart_Click(object sender, RoutedEventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống.", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa toàn bộ giỏ hàng?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _cart.Clear();
                RefreshCart();
            }
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            int total = _cart.Sum(x => x.UnitPrice * x.Qty);

            PaymentChoiceWindow payment = new PaymentChoiceWindow(total);
            bool? result = payment.ShowDialog();

            if (result == true)
            {
                _cart.Clear();
                RefreshCart();
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            Close();
        }
    }
}