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
        private string TypeName;

        public Account(string number, Customer holder)
        {
            transactions = new List<Transaction>();
            holders = new List<Customer>();
            connectedCards = new List<PaymentCard>();
            Number = number;
            holders.Add(holder);
            SetName();
        }

        public void SetName(string name = null)
        {
            if (name == null)
            {
                this.TypeName = Number.ToString();
            }
            else
            {
                this.TypeName = name;
            }
            
        }

        public bool MakeTransaction(decimal amount, int client, string cardNumber, string bank)
        {
            DbFacade db = DbFacade.GetInstance();

            // Conduct transaction
            if (Balance >= amount)
            {
                amount = Decimal.Negate(amount);
                DateTime dt = db.MakeTransaction(Number, amount, true,client, cardNumber, bank);

                Transaction newT = new Transaction(amount, this, dt);
                transactions.Add(newT);

                return true;
            }
            else
            {
                throw new Exception("Otillräkliga tillgångar på kontot.");
            }

        }

        private void LoadTransactions()
        {
            DbFacade db = DbFacade.GetInstance();
            transactions = db.Transactions(this.Number);
            foreach (Transaction t in transactions)
            {
                t.Account = this;
            }
        }

        public string Number
        {
            get;
            private set;
        }

        public decimal Balance
        {
            get
            {
                LoadTransactions();
                Decimal result = new Decimal(0);

                List<Decimal> tranAmouns = (from tran in transactions select tran.Amount).ToList();
                foreach (Decimal tranAmount in tranAmouns)
                {
                    result = result + tranAmount;
                }

                return result;
            }
            private set
            {
                Balance = value;
            }
        }

        public List<Customer> getHolders()
        {
            return holders;
        }

        public bool IsHolder(Customer c)
        {
            foreach (Customer cust in holders)
            {
                if (cust.Ssn == c.Ssn)
                {
                    return true;
                }
            }

            return false;
        }

        //public method that returns the five latest transactions.
        public List<String> latestFiveTransactions()
        {
            LoadTransactions();
            List<String> lastFive = new List<String>();
            List<Transaction> myTransaction = transactions.OrderByDescending(i => i.Time).Take(5).ToList();
            foreach (var transaction in myTransaction)
            {
                lastFive.Add(transaction.ToString());
            }
            return lastFive;
        }

    }
}