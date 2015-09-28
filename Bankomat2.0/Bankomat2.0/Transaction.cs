using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class Transaction : iEvent
    {

        private decimal amount;

        public Transaction (decimal amount)
        {
            this.Amount = amount;
        } 

        public decimal Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }

        public string Account { get; set; }

        public DateTime datum
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

        public string description
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

        public bool outcome
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