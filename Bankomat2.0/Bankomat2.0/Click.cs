using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class Click : iEvent
    {

        private string ATM;

        public Click(string ATM)
        {
            this.atm = ATM;
        }

        public string atm
        {
            get { return this.ATM; }
            set { this.ATM = value; }
        }

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