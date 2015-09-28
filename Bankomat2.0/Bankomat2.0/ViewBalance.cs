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

        public string Account
        {
            get { return this.account; }
            set { this.account = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public string Client
        {
            get
            {
                throw new NotImplementedException();
            }

            set
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

            set
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

            set
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

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}