using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class ViewBalance : iEvent
    {
        private string account;
        private decimal balance;

        public ViewBalance(int client, string account, string description, decimal balance, bool outcome)
        {
            Client = client;
            Account = account;
            Balance = balance;
            Outcome = outcome;
            Description = description;
        }

        public string Account
        {
            get { return account; }
            private set
            {
                account = value;
            }
        }

        public decimal Balance
        {
            get { return this.balance; }
            private set
            {
                balance = value;
            }
        }

        public int Client
        {
            get
            {
                throw new NotImplementedException();
            }
            private set {}
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
            private set{}
        }

        public bool Outcome
        {
            get
            {
                throw new NotImplementedException();
            }
            private set {}
        }
    }
}