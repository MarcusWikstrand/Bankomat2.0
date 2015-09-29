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

        public Bank()
        {
            paymentCards = new Dictionary<string, PaymentCard>();
            customers = new Dictionary<string, Customer>();
            SeedBankWithFakeData();
        }

        /// <summary>
        /// Hittar det kopplade kontot och genomför uttaget
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool ConductTransaction(string cardNumber, decimal amount, int clientId)
        {
            PaymentCard pc = paymentCards[cardNumber];
            Account currentAccount = pc.connectedAccount;
            currentAccount.MakeTransaction(amount);
            return true;
        }

        public bool Authenticate(string card, int pin, int clientID)
        {
            PaymentCard pc = paymentCards[card];
            if (pc.Pin == pin)
            {
                return true;
            }
            else
            {
                pc.RegisterFailedAuthAttempt();
                return false;
            }

        }

        public List<string> GetHolderAccounts(string selectedCard)
        {
            PaymentCard pc = paymentCards[selectedCard];
            Customer c = pc.Holder;
            List<string> cAccounts = (from account in Accounts where account.Value.Holders.Contains(c) select account.Key) as List<string>;

            return cAccounts;
        }

        public decimal GetBalance(string number, int clientId)
        {
            Account a = Accounts[number];
            Decimal balance = a.Balance;
            return balance;
        }

        private void SeedBankWithFakeData()
        {
            // Customers
            Customer c1 = new Customer("199017179999", "Kalle", "Karlsson");
            Customer c2 = new Customer("199017178888", "Bo", "Bosson");
            Customer c3 = new Customer("199017177777", "Li", "Lisson");
            Customer c4 = new Customer("199017176666", "Dan", "Dansson");
            Customer c5 = new Customer("199017175555", "Pelle", "Pettersson");
            customers.Add(c1.Ssn, c1);
            customers.Add(c2.Ssn, c2);
            customers.Add(c3.Ssn, c3);
            customers.Add(c4.Ssn, c4);
            customers.Add(c5.Ssn, c5);

            // Accounts 
            Account a1 = new Account("51425555555", c1);
            Account a2 = new Account("51426666666", c2);
            Account a3 = new Account("51427777777", c3);
            Account a4 = new Account("51428888888", c4);
            Account a5 = new Account("51429999999", c5);
            Accounts.Add(a1.Number, a1);
            Accounts.Add(a2.Number, a2);
            Accounts.Add(a3.Number, a3);
            Accounts.Add(a4.Number, a4);
            Accounts.Add(a5.Number, a5);

            // transactions 
            a1.MakeTransaction(-1000);
            a1.MakeTransaction(-500);
            a1.MakeTransaction(-200);
            a1.MakeTransaction(-100);
            a2.MakeTransaction(-1500);
            a3.MakeTransaction(-300);
            a3.MakeTransaction(-300);
            a4.MakeTransaction(-200);
            a4.MakeTransaction(-300);
            a5.MakeTransaction(-300);
            a5.MakeTransaction(-100);
            a5.MakeTransaction(-300);


            // Payment cards
            PaymentCard p1 = new PaymentCard(1111, 00000000, "51425555555", c1, a1);
            PaymentCard p2 = new PaymentCard(2222, 00000000, "51426666666", c2, a2);
            PaymentCard p3 = new PaymentCard(3333, 00000000, "51427777777", c3, a3);
            PaymentCard p4 = new PaymentCard(4444, 00000000, "51428888888", c4, a4);
            PaymentCard p5 = new PaymentCard(5555, 00000000, "51429999999", c5, a5);
            paymentCards.Add(p1.Pan, p1);
            paymentCards.Add(p2.Pan, p2);
            paymentCards.Add(p3.Pan, p3);
            paymentCards.Add(p4.Pan, p4);
            paymentCards.Add(p5.Pan, p5);

        }
        //Display the five latest events to take place within this specific account.
        public List<String> GetLatestFiveTransactions(string accountNumber, int clientID)
        {
            Account currentAccount = Accounts[accountNumber];
            return currentAccount.latestFiveTransactions();

        }

        #region props

            //Bank identification code
        private string Bic { get; set; }

        // Bank namn
        private string Name { get; set; }

        // Account list
        private Dictionary<string, Account> Accounts { get; set; }

        // max cash withdrawal per day
        private int MaxDailyWithdrawalAmount { get; set; }

        //max cash withdrawal per time
        private int MaxSingleWithdrawalAmount { get; set; }

        #endregion
    }
}