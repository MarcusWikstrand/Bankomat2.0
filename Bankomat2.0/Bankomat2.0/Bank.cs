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
        //max cash withdrawal per time
        private int maxSingleWithdrawalAmount { get; set; }
        // log 
        private List<iEvent> eventLog { get; set; }
        // 
        private Dictionary<string, PaymentCard> paymentCards;

        /// <summary>
        /// Hittar det kopplade kontot och genomför uttaget
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool ConductTransaction(string cardNumber, decimal amount)
        {
            PaymentCard pc = paymentCards[cardNumber];
            Account currentAccount = pc.connectedAccount;
            currentAccount.MakeTransaction(amount);
            return true;
        }

        public void LogEvent(string clientID, int pin, PaymentCard card, bool outcome)
        {
            Authentification auth = new Authentification(pin, clientID, "Inloggningsförsök", outcome);
            eventLog.Add(auth);
        }

        public void GetPerson(string SSN)
        {
            //SQL
        }

        public bool Authenticate(string card, int pin, string clientID)
        {
            PaymentCard pc = paymentCards[card];
            if (pc.pin == pin)
            {
                LogEvent(clientID, pin, pc, true);
                return true;
            }
            else
            {
                pc.RegisterFailedAuthAttempt();
                LogEvent(clientID, pin, pc, false);
                return false;
            }

        }
    }
}