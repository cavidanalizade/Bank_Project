using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Project
{
    internal interface IAccount
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        public string CurrencyType { get; set; }

    }
}
