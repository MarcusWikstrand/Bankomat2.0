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
            //// store the selected account name
            //Session["selectedAccountName"] = ListOfAccounts.SelectedValue;

            // Get the total from this account
            lblSummaSaldo.Text = atm.ViewBalance(ListOfAccounts.SelectedValue).ToString();
            // Show the Account name info
            lblShowAccount.Visible = true;
            lblSummaSaldo.Visible = true;
            lblValuta.Visible = true;
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Server.Transfer("MainMenu.aspx");
        }
    }
}