using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class ATM
    {
        //Bankomatens ID för event logg
        string serialNumber;
        //Max uttag för just den här bankomaten
        int maxWithdrawalAmount;
        //Vem använder bankomaten
        string currentUser;
        //Vilket konto används för transaktionen
        string selectedAccount;

        //Lista med tilgängliga sedlar
        List<Banknote> currentlyAvailableBanknotes = new List<Banknote>();

        public void Withdraw()
        {

        }

        public void RegisterEvent()
        {

        }
    }
}