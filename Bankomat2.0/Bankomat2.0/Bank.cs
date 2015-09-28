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
            customers = new Dictionary<string, Customer>();
        }
        //Bank identification code
        private string Bic { get; set; }
        // Bank namn
        private string Name { get; set; }
        // Account list
        private Dictionary<string, Account> Accounts { get; set; }
        // max cash withdrawal per day
        private int maxDailyWithdrawalAmount { get; set; }
        //max cash withdrawal per time
        private int maxSingleWithdrawalAmount { get; set; }
        // log 
        private List<iEvent> eventLog { get; set; }
        // 
        private Dictionary<string, PaymentCard> paymentCards;

        private Dictionary<string, Customer> customers;

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

        public void LogEvent(string clientId, string accountNumber, Decimal balance)
        {
            ViewBalance vb = new ViewBalance(clientId, accountNumber, "Viewed the specified account balance.", balance, true);
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

        public List<string> GetHolderAccounts(string selectedCard)
        {
            PaymentCard pc = paymentCards[selectedCard];
            Customer c = pc.holder;
            List<string> cAccounts = (from account in Accounts where account.Value.holders.Contains(c) select account.Key) as List<string>;

            return cAccounts;
        }

        public decimal GetBalance(string accountNumber, string clientId)
        {
            Account a = Accounts[accountNumber];
            Decimal balance = a.Balance;
            LogEvent(clientId, accountNumber, balance);

            return balance;
        }
    }
}