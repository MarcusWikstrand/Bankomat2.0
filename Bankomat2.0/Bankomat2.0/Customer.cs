﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class Customer
    {
        public string ssn { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        // Add a link to the actual PayCard that is linked to this person.
        public PaymentCard card {get; set; }

    }
}