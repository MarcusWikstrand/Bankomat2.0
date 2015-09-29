using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class PaymentCard
    {
        private int failedAuthenticationAttempts;
        private bool active;

        public PaymentCard(int pin, int iin, string pan, Customer holder, Account account)
        {
            Pin = pin;
            Iin = iin;
            Pan = pan;
            Holder = holder;
            ConnectedAccount = account;
            active = true;
        }

        public void RegisterFailedAuthAttempt()
        {
            failedAuthenticationAttempts++;
            if (failedAuthenticationAttempts >= 3)
            {
                active = false;
                throw new Exception("Three failed attemtps to Authenticate");
            }
        }

        public Account connectedAccount { get; set; }

        public bool IsActive()
        {
            return active;
        }


        #region props

        public int Pin { get;}

        public int Iin { get;}

        public string Pan { get; }

        public Customer Holder { get; set; }

        public Account ConnectedAccount { get; }

        #endregion
    }
}