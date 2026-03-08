using System.Collections.Generic;
using System.Windows;

namespace MiniPOS
{
    public partial class StaffManagementWindow : Window
    {
        public class StaffItem
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public string Role { get; set; }
        }

        public StaffManagementWindow()
        {
            InitializeComponent();

            lvStaff.ItemsSource = new List<StaffItem>
            {
                new StaffItem { Code = "2033240309", Name = "Võ Văn Thái", Role = "Thu ngân" },
                new StaffItem { Code = "2033240310", Name = "Thảo", Role = "Bán hàng" },
                new StaffItem { Code = "2033240311", Name = "Trân", Role = "Quản lý ca" }
            };
        }
    }
}