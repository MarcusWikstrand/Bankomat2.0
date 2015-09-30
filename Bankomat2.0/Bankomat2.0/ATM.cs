using ATMProject._0;
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
            ReadNumBanknotesInAtm();
        }

        public void Withdraw(int withdrawalAmount)
        {
            if (!BanknotesAvailable())
            {
                throw new Exception("Tekniskt fel (dvs. Pengarna är slut (dont panic))");
            }

            if (ValidateWithdrawalAmount(withdrawalAmount) == false)
            {
                throw new Exception("Ogiltigt Belopp");
            }

            ReservBanknotes(withdrawalAmount);
            bank.ConductTransaction(EnteredCardNumber, withdrawalAmount, clientId);
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

            // Check that the amount is positive
            if (withdrawalAmount <= 0)
            {
                valid = false;
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
                        Banknote bn = (from banknote in currentlyAvailableBanknotes where banknote.Denomination == denomination select banknote).FirstOrDefault();

                        // If there is an available banknote of the denomination we move it to reserved banknotes.
                        if (bn != null)
                        {
                            reservedBanknotes.Add(bn);
                            currentlyAvailableBanknotes.Remove(bn);
                        }
                        else
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
                throw new Exception(@"Tekniskt fel (dvs. inte tillräckligt med pengar i maskinen (don't panic))");
            }

            return reservedBanknotes;
        }

        public bool BanknotesAvailable()
        {
            return (currentlyAvailableBanknotes.Count > 0) ? true : false;
        }

        private List<int> AvailableDenominations()
        {
            List<int> denominations = (from banknote in currentlyAvailableBanknotes select banknote.Denomination).Distinct().ToList();
            return denominations;
        }

        public bool Authenticate(string cardNumber, int pin)
        {
            bool authResult = false;

            if (bank.Authenticate(cardNumber, pin, clientId))
            {
                EnteredCardNumber = cardNumber;
                authResult = true;
            }
            else
            {
                EnteredCardNumber = null;
                throw new Exception("Incorrect pin");
            }


            return authResult;
        }

        public List<string> GetHolderAccounts()
        {
            if (EnteredCardNumber != null)
            {
                return bank.GetHolderAccounts(EnteredCardNumber);
            }
            else
            {
                throw new Exception("No card Entered.");
            }
        }

        public decimal ViewBalance(string accountNumber)
        {
            return bank.GetBalance(accountNumber, EnteredCardNumber, clientId);
        }

        public decimal ViewConnectedAccountBalance()
        {
            return bank.GetConnectedAccountBalance(EnteredCardNumber, clientId);
        }

        private void ReadNumBanknotesInAtm()
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

        ///Display the five latest transactions to take place within this specific account.
        public List<String> getFiveLatestTransactions(string accountNumber)
        {
            return bank.GetLatestFiveTransactions(accountNumber, clientId);
        }

        #region props

        private string EnteredCardNumber { get; set; }

        #endregion
    }
}