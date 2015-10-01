using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bankomat2._0
{
    public partial class FinishedTransactionPage : System.Web.UI.Page
    {
        public ATM atm;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Menu_Click(object sender, EventArgs e)
        {
            // Mke sure we have udated ATM
            Session["ATM"] = atm;
            Server.Transfer("MainMenu.aspx");
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
            Server.Transfer("WelcomePage.aspx");
        }

        protected void ButtonKvitto_Click(object sender, EventArgs e)
        {
            Server.Transfer("ReceiptPage.aspx");
        }
    }
}