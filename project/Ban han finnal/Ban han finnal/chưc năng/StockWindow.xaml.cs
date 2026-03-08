using System.Collections.Generic;
using System.Windows;

namespace MiniPOS
{
    public partial class StockWindow : Window
    {
        public class StockItem
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public int Quantity { get; set; }
            public string Status { get; set; }
        }

        public StockWindow()
        {
            InitializeComponent();

            lvStock.ItemsSource = new List<StockItem>
            {
                new StockItem { Name = "Trà chanh", Category = "Nước ngọt", Quantity = 25, Status = "Còn hàng" },
                new StockItem { Name = "Bánh socola", Category = "Bánh ngọt", Quantity = 10, Status = "Sắp hết" },
                new StockItem { Name = "Snack BBQ", Category = "Snack", Quantity = 40, Status = "Còn hàng" },
                new StockItem { Name = "Omachi bò hầm", Category = "Mì gói", Quantity = 8, Status = "Sắp hết" },
                new StockItem { Name = "Cà phê sữa", Category = "Cà phê", Quantity = 30, Status = "Còn hàng" }
            };
        }
    }
}