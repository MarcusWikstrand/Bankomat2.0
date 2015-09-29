using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class Transaction
    {
        private Account account;

        public Transaction(decimal amount, Account account)
        {
            Amount = amount;
            this.account = account;
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
            private set{}
        }

        public int Client
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DateTime Time
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Outcome
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}