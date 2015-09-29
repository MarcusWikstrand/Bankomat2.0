using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class Account
    {
        private List<Transaction> transactions;
        private List<Customer> holders;
        private List<PaymentCard> connectedCards;

        public Account(string number, Customer holder)
        {
            transactions = new List<Transaction>();
            holders = new List<Customer>();
            connectedCards = new List<PaymentCard>();
            Number = number;
            holders.Add(holder);
        }

        public bool MakeTransaction(decimal amount)
        {
            if (Balance >= amount)
            {
                decimal newBalance = Balance - amount;
                Balance = newBalance;
                Transaction newT = new Transaction(amount, this);
                transactions.Add(newT);

                return true;
            }
            else
            {
                throw new Exception("Otillräkliga tillgångar på kontot.");
            }
            
        }

        /// <summary>
        /// Stored procedure i SQL, inte färdigt.
        /// </summary>
        private void CheckThisDayTransactions()
        {

            DateTime today = DateTime.Now.Date;
            
            
        }

        public string Number {
            get;
            private set;
        }

        public decimal Balance
        {
            get;
            private set;
        }

        public List<Customer> Holders
        {
            get;
        }

        //public method that returns the five latest transactions.
        public List<String> latestFiveTransactions()
        {
            List<String> lastFive = new List<String>();
            List <Transaction> myTransaction = transactions.OrderByDescending(i => i.Time).Take(5).ToList();
            foreach (var transaction in myTransaction)
            {
                lastFive.Add(transaction.ToString());
            }
            return lastFive;
        }
        
    }
}