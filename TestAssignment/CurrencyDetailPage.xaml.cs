using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestAssignment
{
    /// <summary>
    /// Interaction logic for CurrencyDetailPage.xaml
    /// </summary>
    public partial class CurrencyDetailPage : Page
    {
        private CryptoCurrency _crypto;

        public CurrencyDetailPage(CryptoCurrency crypto)
        {
            InitializeComponent();
            _crypto = crypto;
            LoadCurrencyDetails();
        }

        private void LoadCurrencyDetails()
        {
            NameText.Text = _crypto.Name;
            PriceText.Text = _crypto.Price.ToString();
            ChangeText.Text = _crypto.Change.ToString();
            VolumeText.Text = "Тут буде обсяг торгів"; // Або з API

            // Тут можна додати інформацію про ринки
            MarketsListView.ItemsSource = new List<string>
        {
            "Binance - $30100",
            "Coinbase - $30050",
            "Kraken - $30080"
        };
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();  // Повертає на попередню сторінку
            }
        }
    }
}
