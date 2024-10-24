using System;
using System.Collections.Generic;
using System.Linq;
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
}
