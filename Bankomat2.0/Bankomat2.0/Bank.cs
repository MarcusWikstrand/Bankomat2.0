using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class Bank
    {
        public Bank()
        {
            paymentCards = new Dictionary<string, PaymentCard>();
        }
        //Bank identification code
        private string Bic { get; set; }
        // Bank namn
        private string Name { get; set; }
        // Account list
        private Dictionary<string, Account> accounts { get; set; }
        // max cash withdrawal per day
        private int maxDailyWithdrawalAmount { get; set; }
        // log 
        private List<iEvent> eventLog { get; set; }
        // 
        private Dictionary<string, PaymentCard> paymentCards;
        public bool ConductTransaction()
        {
            return true;
        }

        public bool LogEvent()
        {
            return true;
        }

        public void GetPerson(string SSN)
        {
            //SQL
        }
        public bool Authenticate(string card, string pin, string clientID)
        {
            PaymentCard pc = paymentCards[card];
            if (pc.pin == pin)
            {
                return true;
            }
            else
            {
                pc.RegisterFailedAuthAttempt();
                return false;
            }

        }
    }
}