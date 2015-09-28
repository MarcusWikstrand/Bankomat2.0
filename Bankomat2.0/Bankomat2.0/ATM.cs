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
        //Bankomatens ID för event logg
        private string ClientID { get;}

        //Max uttag för just den här bankomaten
        private const int MaxWithdrawalAmount = 5000;

        // vilken bank?
        private Bank Bank;

        //Vilket konto används för transaktionen
        public string SelectedCard { get; set; } //Tilldelas värdet via forms

        //Lista med tilgängliga sedlar
        List<Banknote> currentlyAvailableBanknotes = new List<Banknote>();

        public void Withdraw(int withdrawalAmount)
        {
            withdrawalAmount = 0; //Kopplas till forms senare
            if (withdrawalAmount <= 2000)
            {

            }
            else new Exception("Amount is too big for this machine");//Specificiera: ska ett konto kunna ta ut max 2000 per dygn eller per gång?

        }

        public void RegisterEvent()
        {

        }
        private bool Authenticate(string card, string pin)
        {
            try
            {
                if (this.Bank.Authenticate(card, pin, ClientID))
                {
                    SelectedCard = card;
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Put ex on screen 
                SelectedCard = null;
                throw;
            }
            return false;

        }
    }
}