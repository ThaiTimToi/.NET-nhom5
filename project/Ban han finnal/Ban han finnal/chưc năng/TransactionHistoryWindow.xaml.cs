using System.Collections.Generic;
using System.Windows;

namespace MiniPOS
{
    public partial class TransactionHistoryWindow : Window
    {
        public class HistoryItem
        {
            public string Code { get; set; }
            public string Date { get; set; }
            public string Staff { get; set; }
            public string Total { get; set; }
            public string Method { get; set; }
        }

        public TransactionHistoryWindow()
        {
            InitializeComponent();

            lvHistory.ItemsSource = new List<HistoryItem>
            {
                new HistoryItem { Code = "GD001", Date = "08/03/2026 09:10", Staff = "Võ Văn Thái", Total = "85,000 đ", Method = "Tiền mặt" },
                new HistoryItem { Code = "GD002", Date = "08/03/2026 10:25", Staff = "Thảo", Total = "120,000 đ", Method = "Momo" },
                new HistoryItem { Code = "GD003", Date = "08/03/2026 11:40", Staff = "Trân", Total = "56,000 đ", Method = "Banking" }
            };
        }
    }
}