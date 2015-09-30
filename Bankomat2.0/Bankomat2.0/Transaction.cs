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

        public string Account
        {
            get
            {
                return account.Number;
            }
            set{}
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

        public string Description
        {
            get;
        }

        public bool Outcome
        {
            get;
        }

        //Override method to ensure that a method to return the five latest transactions can work.
        public override string ToString()
        {
            return Amount + Account + Client + Time + Description + Outcome;
        }
    }
}