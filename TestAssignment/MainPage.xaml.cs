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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public List<CryptoCurrency> ?TopCryptos { get; set; }

        public MainPage()
        {
            InitializeComponent();
            LoadTopCryptos(); // Завантаження даних
        }

        private void LoadTopCryptos()
        {
            // Тут ви можете підключити API для отримання криптовалют
            // Приклад: завантаження тестових даних
            TopCryptos = new List<CryptoCurrency>
        {
            new CryptoCurrency { Rank = 1, Name = "Bitcoin", Price = 30000, Change = 1.2 },
            new CryptoCurrency { Rank = 2, Name = "Ethereum", Price = 2000, Change = 2.3 },
            // додати більше валют
        };

            cryptoDataGrid.ItemsSource = TopCryptos;
        }

        private void CryptoDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (cryptoDataGrid.SelectedItem is CryptoCurrency selectedCrypto)
            {
                // Перехід на сторінку детальної інформації
                NavigationService.Navigate(new CurrencyDetailPage(selectedCrypto));
            }
        }
    }
}
