using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class Account
    {
        private string number { get; set; }
        public decimal Balance { get; set; }
        private List<Transaction> transactions { get; set; }
        public List<Customer> holders { get; set; }
        private List<PaymentCard> connectedCards { get; set; }

        public bool MakeTransaction(decimal amount)
        {
            if (this.Balance >= amount)
            {
                decimal newBalance = Balance - amount;
                Balance = newBalance;
                // Sparar i loggen
                Transaction newTA = new Transaction(Balance);
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