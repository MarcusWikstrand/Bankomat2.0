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

        public PaymentCard(int pin, string cardNumber, Customer holder, Account account)
        {
            CardNumber = cardNumber;
            Pin = pin;
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

        public bool IsActive()
        {
            return active;
        }


        #region props

        public string CardNumber { get; set; }

        public int Pin { get;}

        public Customer Holder { get; set; }

        public Account ConnectedAccount { get; private set; }

        #endregion
    }
}