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
    /// Interaction logic for CalculatorPage.xaml
    /// </summary>
    public partial class CalculatorPage : Page
    {
        private Dictionary<string, decimal> cryptoPrices = new Dictionary<string, decimal>();

        public CalculatorPage(List<CryptoCurrency> cryptocurrencies)
        {
            InitializeComponent();
            foreach (var crypto in cryptocurrencies)
            {
                CryptoComboBox.Items.Add(crypto);
                cryptoPrices[crypto.Name] = crypto.Price;
            }
        }
        // Оновлення вибраної криптовалюти
        private void CryptoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResultText.Text = string.Empty; // Очищуємо результат при зміні вибору
        }

        // Розрахунок вартості
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (CryptoComboBox.SelectedItem is CryptoCurrency selectedCrypto &&
                decimal.TryParse(AmountTextBox.Text, out decimal amount))
            {
                if (cryptoPrices.TryGetValue(selectedCrypto.Name, out decimal price))
                {
                    decimal result = amount * price;
                    ResultText.Text = $"{amount} {selectedCrypto.Name} is worth {result:C}";
                }
                else
                {
                    ResultText.Text = "Error: Unable to retrieve price data.";
                }
            }
            else
            {
                ResultText.Text = "Please select a cryptocurrency and enter a valid amount.";
            }
        }
    }
}
