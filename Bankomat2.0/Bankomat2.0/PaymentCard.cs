using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class PaymentCard
    {
        public int iin { get; set; }
        public int pan { get; set; }
        public Customer holder { get; set; }
        public Dictionary<int, Account>  connectedAccounts { get; set; }
    }
}