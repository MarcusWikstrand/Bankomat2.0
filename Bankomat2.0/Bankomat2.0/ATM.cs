using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class ATM
    {
        public ATM()
        {
            Bank = new Bank();

        }
        //Bankomatens ID för event logg
        private string SerialNumber { get; set; }

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
                Bank.ConductTransaction(SelectedCard, withdrawalAmount);
        }
            else new Exception("Amount is too big for this machine");//Specificiera: ska ett konto kunna ta ut max 2000 per dygn eller per gång?
            
        }

        public void RegisterEvent()
        {

        }
        private bool Authenticate(string card, string pin)
        {
            if (this.Bank.Authenticate(card, pin))
            {
                return true;
            }
            return false;

        }
    }
}