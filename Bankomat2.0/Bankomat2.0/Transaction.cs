using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class Transaction
    {
        private Account account;

        public Transaction(decimal amount, DateTime dt)
        {
            Amount = amount;
            Time = dt;
        }

        public Transaction(decimal amount, Account account, DateTime dt)
        {
            Amount = amount;
            this.account = account;
            Time = dt;
        }

        public decimal Amount
        {
            get;
            private set;
        }

        public Account Account
        {
            get
            {
                return account;
            }
            set
            {
                account = value;
            }
        }

        public int Client
        {
            get;
        }

        public DateTime Time
        {
            get;
            private set; 
        }

        public bool Outcome
        {
            get;
        }

        //Override method to ensure that a method to return the five latest transactions can work.
        public override string ToString()
        {
            return ($"  {Amount}, {Time}");
        }
    }
}