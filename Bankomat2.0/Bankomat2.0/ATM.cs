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
            SeedAtmWithFakeMoney();
        }

        public void Withdraw(int withdrawalAmount)
        {
            if (!BanknotesIsAvailable())
            {
                throw new Exception("No banknotes availabale in the ATM.");
            }

            if (ValidateWithdrawalAmount(withdrawalAmount) == false)
            {
                throw new Exception("Invalid amount.");
            }

            ReservBanknotes(withdrawalAmount);
            bank.ConductTransaction(SelectedCardNumber, withdrawalAmount, clientId);
        }

        private bool ValidateWithdrawalAmount(int withdrawalAmount)
        {
            bool valid = true;

            // Check if the withdrawal amount is evenly devisible with the currently available denominations.
            foreach (int denomination in AvailableDenominations())
            {
                if ((withdrawalAmount % denomination) == 0)
                {
                    valid = true;
                    break;
                }
                else
                {
                    valid = false;
                }
            }

            return valid;
        }

        private List<Banknote> ReservBanknotes(int amount)
        {
            List<Banknote> reservedBanknotes = new List<Banknote>();

            // Gets the available denominations and sort them by size, biggest first.
            List<int> denominationsOrdered = AvailableDenominations();
            denominationsOrdered.Sort();
            denominationsOrdered.Reverse();

            // Check how many of each dnomination that is nedded and add them to the list of needed banknotes.
            int remainingAmount = amount;

            foreach (int denomination in denominationsOrdered)
            {
                if ((remainingAmount / denomination) > 0)
                {
                    int numOfThisDenomination = remainingAmount / denomination;

                    for (int i = 0; i <= numOfThisDenomination; i++)
                    {
                        // Moves the needed banknotes from the currently available banknotes to the list of reserved banknotes.
                        Banknote bn = (from banknote in currentlyAvailableBanknotes where banknote.Denomination == denomination select banknote).First();

                        // If there is an available banknote of the denomination we move it to reserved banknotes.
                        if (bn != null)
                        {
                            reservedBanknotes.Add(bn);
                            currentlyAvailableBanknotes.Remove(bn);
                        } else
                        {
                            numOfThisDenomination--;
                        }
                        
                    }

                    remainingAmount -= (numOfThisDenomination * denomination);
                }
            }

            // If the available banknotes does not cover the full amount we throw an exception.
            if (remainingAmount > 0)
            {
                currentlyAvailableBanknotes.AddRange(reservedBanknotes);
                throw new Exception(@"Not enough banknotes in the ATM.");
            } 

            return reservedBanknotes;
        }

        public bool BanknotesIsAvailable()
        {
            return (currentlyAvailableBanknotes.Count > 0) ? true : false;
        }

        private List<int> AvailableDenominations()
        {
            List<int> denominations = (from banknote in currentlyAvailableBanknotes select banknote.Denomination).Distinct() as List<int>;
            return denominations;
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
                } else
                {
                    throw new Exception("Incorrect pin");
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
        ////Display the five latest transactions to take place within this specific account.
        public void getFiveLatestTransactions(string accountNumber)
        {
            bank.GetLatestFiveTransactions(accountNumber, clientId);
        }

        #region props

        private string SelectedCardNumber { get; set; } //Tilldelas värdet via forms

        #endregion
    }
}