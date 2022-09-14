using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Content
    {
        public string From { get; set; }
        public string To { get; set; }
        public double Amount { get; set; }
        public Content(string from, string to, double amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }
    }
}
