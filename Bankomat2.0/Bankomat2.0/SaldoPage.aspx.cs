using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bankomat2._0
{
    public partial class SaldoPage : System.Web.UI.Page
    {
        public ATM atm;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ATM"] != null)
            {
                // Vi har en ATM

                atm = (ATM)Session["ATM"];
            }
            else
            {
                atm = new ATM(123456789);
                Session["ATM"] = atm;
            }

            // populate list of accounts.
            foreach (var accountname in atm.GetHolderAccounts())
            {
                ListOfAccounts.Items.Add(accountname);
            }
            

        }
    }
}