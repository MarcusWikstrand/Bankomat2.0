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
            // clear first
            ListOfAccounts.Items.Clear();
            try
            {
                foreach (var accountname in atm.GetHolderAccounts())
                {
                    ListOfAccounts.Items.Add(accountname);
                }
            }
            catch (Exception ex)
            {
                ListOfAccounts.Items.Clear();
                ListOfAccounts.Items.Add(ex.Message);

            }



        }

        protected void ListOfAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear both just in case
            ListTransactions.Items.Clear();
            int index = ListOfAccounts.SelectedIndex < 0 ? 0 : ListOfAccounts.SelectedIndex;
            string account = ListOfAccounts.Items[index].Text;
            // Get the total from this account
            lblSummaSaldo.Text = atm.ViewBalance(account).ToString();
            // Show the Account name info
            lblShowAccount.Visible = true;
            lblSummaSaldo.Visible = true;
            lblValuta.Visible = true;

            // Five latest transactions stuff
            foreach (var item in atm.getFiveLatestTransactions(ListOfAccounts.Items[index].Value))
            {
                ListTransactions.Items.Add(item);
            }


            lblTransactions.Visible = true;
            ListTransactions.Visible = true;
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Server.Transfer("MainMenu.aspx");
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}