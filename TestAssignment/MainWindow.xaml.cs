﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        // Змінна для зберігання останньої обраної криптовалюти
        private CryptoCurrency lastSelectedCrypto;
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainPage());
        }
        // Обробники для навігації
        #region
        private void NavigateToHome(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainPage());
        }

        private void NavigateToCalculator(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CalculatorPage(GetCryptocurrencies()));
        }

        private void NavigateToCurrencyDetails(object sender, RoutedEventArgs e)
        {
            
            MainFrame.Navigate(new CurrencyDetailPage(lastSelectedCrypto));
        }
        #endregion

        // Метод для вибору криптовалюти
        public void SelectCrypto(CryptoCurrency crypto)
        {
            lastSelectedCrypto = crypto;
            MainFrame.Navigate(new CurrencyDetailPage(crypto));
        }

        // Метод для отримання списку криптовалют
        private List<CryptoCurrency> GetCryptocurrencies()
        {
            if (MainFrame.Content is MainPage mainPage && mainPage.TopCryptos != null)
            {
                return mainPage.TopCryptos;
            }

            MessageBox.Show("Cryptocurrency data is not available.");
            return new List<CryptoCurrency>();
        }
        //private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        string query = SearchTextBox.Text.ToLower();
        //        var foundCrypto = cryptocurrencies.FirstOrDefault(c => c.Name.ToLower().Contains(query) || c.Symbol.ToLower().Contains(query));

        //        if (foundCrypto != null)
        //        {
        //            // Передаємо знайдений елемент до HomePage для виділення
        //            MainFrame.Navigate(new MainPage(cryptocurrencies, foundCrypto));
        //        }
        //        else
        //        {
        //            MessageBox.Show("Cryptocurrency not found.");
        //        }
        //    }
        //}

    }
}
