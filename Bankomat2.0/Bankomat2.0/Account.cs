using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class Account
    {
        public string number { get; set; }
        public decimal balance { get; set; }
        public List<Transaction> transactions { get; set; }
        public List<Customer> holders { get; set; }

        public bool MakeTransaction(decimal amount)
        {
            if (this.balance >= amount)
            {
                // Maketransaction
                Transaction newTA = new Transaction(balance);
                newTA.Account = this.number;
                newTA.Amount = amount;
                transactions.Add(newTA);
                return true;
            }
            else
            {
                throw new Exception("Not enough money.");
            }
            
        }
    }
}