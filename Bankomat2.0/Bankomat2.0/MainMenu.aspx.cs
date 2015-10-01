using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bankomat2._0
{
    public partial class MainMenu : System.Web.UI.Page
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
        }

        protected void Saldo_Click(object sender, EventArgs e)
        {
            // Mke sure we have udated ATM
            Session["ATM"] = atm;
            Server.Transfer("SaldoPage.aspx");
        }

        protected void Uttag_Click(object sender, EventArgs e)
        {
            // Mke sure we have udated ATM
            Session["ATM"] = atm;
            Server.Transfer("WithdrawalPage.aspx");
        }

        protected void Avbryt_Click(object sender, EventArgs e)
        {
            // Mke sure we have udated ATM
            Session["ATM"] = atm;
            Session.Clear();
            Server.Transfer("WelcomePage.aspx");
        }
    }
}