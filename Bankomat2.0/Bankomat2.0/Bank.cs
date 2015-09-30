using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class Bank
    {
        private Dictionary<string, PaymentCard> paymentCards;
        private Dictionary<string, Customer> customers;
        private Dictionary<string, Account> accounts;
        private DbFacade dbFacade;
        private string bic;

        public Bank()
        {
            bic = "00000001";
            paymentCards = new Dictionary<string, PaymentCard>();
            customers = new Dictionary<string, Customer>();
            accounts = new Dictionary<string, Account>();
            dbFacade = DbFacade.GetInstance();
            LoadCustomerData();
        }

        public bool ConductTransaction(string cardNumber, decimal amount, int clientId)
        {
            PaymentCard pc = paymentCards[cardNumber];
            Account currentAccount = pc.ConnectedAccount;
            currentAccount.MakeTransaction(amount, clientId, cardNumber, Bic);
            return true;
        }

        public bool Authenticate(string card, int pin, int clientID)
        {
            PaymentCard pc = paymentCards[card];
            if (pc.Pin == pin)
            {
                dbFacade.RegisterAuth(pin, true, clientID, card, Bic);
                return true;
            }
            else
            {
                dbFacade.RegisterAuth(pin, false, clientID, card, Bic);
                pc.RegisterFailedAuthAttempt();
                return false;
            }
        }

        public List<string> GetHolderAccounts(string selectedCard)
        {
            PaymentCard pc = paymentCards[selectedCard];
            Customer c = pc.Holder;
            List<string> cAccounts = (from account in accounts where account.Value.getHolders().Contains(c) select account.Key) as List<string>;

            return cAccounts;
        }

        public decimal GetBalance(string number, string card, int clientId)
        {
            Account a = accounts[number];
            Decimal balance = a.Balance;
            dbFacade.RegisterBalanceAccess(number, clientId, card, Bic);
            return balance;
        }

        public decimal GetConnectedAccountBalance(string cardNumber, int clientId)
        {
            PaymentCard pc = paymentCards[cardNumber];
            Account a = pc.ConnectedAccount;
            return GetBalance(a.Number, cardNumber, clientId);
        }

        private void LoadCustomerData()
        {
            List<List<object>> customerData = dbFacade.CustomerData();

            foreach (Customer c in customerData.ElementAt(0))
            {
                customers.Add(c.Ssn, c);
            }

            foreach (Account a in customerData.ElementAt(1))
            {
                accounts.Add(a.Number, a);
            }

            foreach (PaymentCard pc in customerData.ElementAt(2))
            {
                paymentCards.Add(pc.CardNumber, pc);
            }
        }

        //Display the five latest events to take place within this specific account.
        public List<String> GetLatestFiveTransactions(string accountNumber, int clientID)
        {
            Account currentAccount = accounts[accountNumber];
            return currentAccount.latestFiveTransactions();
        }

        #region props

        //Bank identification code
        private string Bic {
            get
            {
                return bic;
            }
            set
            {
                bic = value;
            }
        }

        // Bank namn
        private string Name { get; set; }

        // max cash withdrawal per day
        private int MaxDailyWithdrawalAmount { get; set; }

        //max cash withdrawal per time
        private int MaxSingleWithdrawalAmount { get; set; }

        #endregion
    }
}