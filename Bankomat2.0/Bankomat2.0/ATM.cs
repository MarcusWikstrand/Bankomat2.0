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
        private string SelectedAccount { get; set; }

        //Lista med tilgängliga sedlar
        List<Banknote> currentlyAvailableBanknotes = new List<Banknote>();

        private void Withdraw()
        {

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