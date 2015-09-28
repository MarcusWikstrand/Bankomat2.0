using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class ATM
    {
        public ATM(string id)
        {
            Bank = new Bank();
            ClientID = id;
        }

        #region props
        //Bankomatens ID för event logg
        private string ClientID { get; }

        //Max uttag för just den här bankomaten
        private const int MaxWithdrawalAmount = 5000;

        // vilken bank?
        private Bank Bank;

        //Vilket konto används för transaktionen
        public string SelectedCard { get; set; } //Tilldelas värdet via forms

        //Lista med tilgängliga sedlar
        List<Banknote> currentlyAvailableBanknotes = new List<Banknote>();
        #endregion

        public void Withdraw(int withdrawalAmount)
        {
            withdrawalAmount = 0; //Kopplas till forms senare

            if (currentlyAvailableBanknotes != null)//om det finns pengar i bankomaten, bör förbättras
            {
                // Kontroll för orimliga uttag
                if (CheckNotes() && withdrawalAmount < 100)
                {
                    new Exception("Invalid amount. Enter amount that is dividable by 100.");
                }

                Bank.ConductTransaction(SelectedCard, withdrawalAmount);
            }
            else
            {
                new Exception("There are no money in the machine");
            }
        }

        // Kollar om det finns 100 kr sedlar
        public bool CheckNotes()
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

        public void RegisterEvent()
        {

        }
        private bool Authenticate(string card, int pin)
        {
            try
            {
                if (this.Bank.Authenticate(card, pin, ClientID))
                {
                    SelectedCard = card;
                    return true;
                }
            }
            catch (Exception)
            {
                // Put ex on screen 
                SelectedCard = null;
                throw;
            }
            return false;

        }
    }
}