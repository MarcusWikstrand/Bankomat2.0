using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class PaymentCard
    {
        public string pin { get; set; }
        public int iin { get; set; }
        public int pan { get; set; }
        public Customer holder { get; set; }
        public Dictionary<int, Account>  connectedAccounts { get; set; }
        private int failedAuthenticationAttempts;

        public void RegisterFailedAuthAttempt()
        {
            failedAuthenticationAttempts++;
            if (failedAuthenticationAttempts >= 3)
            {
                throw new Exception("Three failed attemtps to Authenticate");
            }
        }
    }
}