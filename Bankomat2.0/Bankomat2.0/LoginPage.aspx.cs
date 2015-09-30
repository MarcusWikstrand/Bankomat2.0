using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bankomat2._0
{
    public partial class LoginPage : System.Web.UI.Page
    {
        public ATM atm;
        private string cardNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ATM"] != null)
            {
                // Vi har en ATM
                atm = (ATM)Session["ATM"];
            }
            else
            {
                Server.Transfer("WelcomePage.aspx");
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (cardNumber != null && cardNumber == this.DropDownListCards.SelectedItem.Value)
            {
                // Vi har ett kort så fortsätt Logga in med pin
                atm.Authenticate(cardNumber, int.Parse(this.PIN.Text));
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cardNumber = this.DropDownListCards.SelectedItem.Value;

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}