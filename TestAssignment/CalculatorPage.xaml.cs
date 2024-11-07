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
                 CryptoComboBox1.DisplayMemberPath = "Name";
                CryptoComboBox1.Items.Add(crypto);
                cryptoPrices[crypto.Name] = crypto.Price;
                CryptoComboBox2.DisplayMemberPath = "Name";
                CryptoComboBox2.Items.Add(crypto);
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
            if (CryptoComboBox1.SelectedItem is CryptoCurrency cryptoFrom && CryptoComboBox2.SelectedItem is CryptoCurrency cryptoTo && decimal.TryParse(AmountTextBox1.Text, out decimal amount))
            {
                // Отримуємо ціну для обох криптовалют
                if (cryptoPrices.TryGetValue(cryptoFrom.Name, out decimal priceFrom) &&
                    cryptoPrices.TryGetValue(cryptoTo.Name, out decimal priceTo))
                {
                    decimal result = (amount * priceFrom) / priceTo;
                    ResultText.Text = $"{amount} {cryptoFrom.Name} is equivalent to {result:F6} {cryptoTo.Name}";
                }
                else
                {
                    ResultText.Text = "Error: Unable to retrieve price data.";
                }
            }
            else
            {
                ResultText.Text = "Please select both cryptocurrencies and enter a valid amount.";
            }
        }
    }
}
