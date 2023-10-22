using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Project.Models
{
    internal class BankAccount :Bank , IAccount
    {
        public int AccountId { get; set ; }
        public decimal Balance { get ; set ; }
        public string AccountType { get ; set ; }
        public string CurrencyType { get; set ; }

        public BankAccount[] transactions=new BankAccount[0];
        
    }
}
