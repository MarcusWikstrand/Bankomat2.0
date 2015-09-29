using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class ATM
    {
        private int clientId;
        private const int MaxWithdrawalAmount = 5000;
        private Bank bank;
        List<Banknote> currentlyAvailableBanknotes;

        public ATM(int id)
        {
            bank = new Bank();
            clientId = id;
            currentlyAvailableBanknotes = new List<Banknote>();
        }

        public void Withdraw(int withdrawalAmount)
        {
            if (currentlyAvailableBanknotes != null)//om det finns pengar i bankomaten, bör förbättras
            {
                // Kontroll för orimliga uttag
                if (CheckNotes() && withdrawalAmount < 100)
                {
                    throw new Exception("Invalid amount. Enter amount that is dividable by 100.");
                }

                bank.ConductTransaction(SelectedCardNumber, withdrawalAmount);
            }
            else
            {
                throw new Exception("There are no money in the machine");
            }
        }

        // Kollar om det finns 100 kr sedlar
        private bool CheckNotes()
        {
            foreach (var note in currentlyAvailableBanknotes)
            {
                if (note.Denomination == 100)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Authenticate(string cardNumber, int pin)
        {
            bool authResult = false;

            try
            {
                if (bank.Authenticate(cardNumber, pin, clientId))
                {
                    SelectedCardNumber = cardNumber;
                    authResult = true;
                }
            }
            catch (Exception)
            {
                SelectedCardNumber = null;
            }

            return authResult;
        }

        public List<string> GetHolderAccounts()
        {
            return bank.GetHolderAccounts(SelectedCardNumber);
        }

        public decimal ViewBalance()
        {
            return bank.GetBalance(SelectedCardNumber, clientId);
        }
        public decimal ViewBalance(string accountNumber)
        {
            return bank.GetBalance(accountNumber, clientId);
        }

        private void SeedAtmWithFakeMoney()
        {
            // Seeds 5 500sek banknotes
            for (int i = 0; i <= 5; i++)
            {
                Banknote bn = new Banknote(500);
                currentlyAvailableBanknotes.Add(bn);
            }

            // Seeds 10 100sek banknotes
            for (int i = 0; i <= 10; i++)
            {
                Banknote bn = new Banknote(100);
                currentlyAvailableBanknotes.Add(bn);
            }
        }

        #region props

            private string SelectedCardNumber { get; set; } //Tilldelas värdet via forms

        #endregion
    }
}