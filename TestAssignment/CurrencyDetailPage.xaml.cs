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
            if (_crypto == null)
            {
                //очищення стек-панелі від зайвих полів
                stackDetail.Visibility = Visibility.Collapsed;
                CryptoInfoText.Text = "Please return to home and select a cryptocurrency.";
            }
            else
            {  
                LoadCurrencyDetails();
            }
           
        }
        
        private void LoadCurrencyDetails()
        {
            NameText.Text = _crypto.Name;
            PriceText.Text = _crypto.Price.ToString();
            ChangeText.Text = _crypto.Change.ToString();
            VolumeText.Text = _crypto.Volume.ToString(); // Або з API

            // Тут можна додати інформацію про ринки
        //    MarketsListView.ItemsSource = new List<string>
        //{
        //    "Binance - $30100",
        //    "Coinbase - $30050",
        //    "Kraken - $30080"
        //};
        }

       
    }
}
