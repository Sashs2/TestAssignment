using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignment
{
    public class CryptoCurrency
    {
        public int Rank { get; set; }
        public string ?Name { get; set; }
        public decimal Price { get; set; }
        public double Change { get; set; }
        public decimal Volume { get; set; }  // Обсяг торгів
    }

    public class CoinMarketCapService
    {
        private static readonly string ApiKey = "f7ae9c6d-c894-453c-b45e-b3ebfe1f314e"; // Замініть на ваш API-ключ
        private static readonly string BaseUrl = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest";

        public static async Task<List<CryptoCurrency>> GetTopCryptocurrenciesAsync(int limit = 10)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", ApiKey);

                var response = await client.GetAsync($"{BaseUrl}?limit={limit}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<CoinMarketCapResponse>(json);

                    // Перетворюємо отримані дані у список об'єктів CryptoCurrency
                    var cryptocurrencies = new List<CryptoCurrency>();
                    foreach (var cryptoData in data.Data)
                    {
                        cryptocurrencies.Add(new CryptoCurrency
                        {
                            Rank = cryptoData.CmcRank,
                            Name = cryptoData.Name,
                            Price = cryptoData.Quote["USD"].Price,
                            Change = cryptoData.Quote["USD"].PercentChange24H,
                            Volume = cryptoData.Quote["USD"].Volume
                        });
                    }

                    return cryptocurrencies;
                }
                else
                {
                    throw new Exception("Unable to retrieve data from CoinMarketCap API.");
                }
            }
        }

        // Класи для десеріалізації JSON відповіді
        public class CoinMarketCapResponse
        {
            public List<CoinData> ?Data { get; set; }
        }

        public class CoinData
        {

            [JsonProperty("cmc_rank")]
            public int CmcRank { get; set; }

            public string ?Name { get; set; }

            public Dictionary<string, QuoteData> ?Quote { get; set; }
        }

        public class QuoteData

        {
            [JsonProperty("price")]
            public decimal Price { get; set; }

            [JsonProperty("percent_change_24h")]
            public double PercentChange24H { get; set; }
           
            [JsonProperty("volume_24h")]
            public decimal Volume { get; set; }
            
        }
    }

}
