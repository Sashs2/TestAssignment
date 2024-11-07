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

        private async void LoadTopCryptos()
        {
            try
            {
                var topCryptos = await CoinMarketCapService.GetTopCryptocurrenciesAsync();
                TopCryptos = topCryptos;
                cryptoDataGrid.ItemsSource = TopCryptos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cryptocurrencies: " + ex.Message);
            }
        }

        private void CryptoDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (cryptoDataGrid.SelectedItem is CryptoCurrency selectedCrypto)
            {
                //Зберігання останньої обраної криптовалюти
                ((MainWindow)Application.Current.MainWindow).SelectCrypto(selectedCrypto);
                // Перехід на сторінку детальної інформації
                NavigationService.Navigate(new CurrencyDetailPage(selectedCrypto));
            }
        }

    
    }
}
