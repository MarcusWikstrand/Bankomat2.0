﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class Account
    {
        private string number { get; set; }
        private decimal balance { get; set; }
        private List<Transaction> transactions { get; set; }
        private List<Customer> holders { get; set; }
        private List<PaymentCard> connectedCards { get; set; }

        public bool MakeTransaction(decimal amount)
        {
            if (this.balance >= amount)
            {
                decimal newBalance = balance - amount;
                balance = newBalance;
                // Sparar i loggen
                Transaction newTA = new Transaction(balance);
                newTA.Account = this.number;
                newTA.Amount = amount;
                transactions.Add(newTA);
                return true;
            }
            else
            {
                throw new Exception("Not enough money.");
            }
            
            
        }
    }
}