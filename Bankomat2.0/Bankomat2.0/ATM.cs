using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class ATM
    {
        //Bankomatens ID för event logg
        public string SerialNumber { get; set; }

        //Max uttag för just den här bankomaten
        public int MaxWithdrawalAmount { get; set; }

        //Vem använder bankomaten
        public string CurrentUser { get; set; }

        //Vilket konto används för transaktionen
        public string SelectedAccount { get; set; }

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