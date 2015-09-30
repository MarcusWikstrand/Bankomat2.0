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
                try
                {
                    atm.Authenticate(cardNumber, int.Parse(this.PIN.Text));
                    // Gå vidare till
                    Server.Transfer("MainMenu.aspx");
                }
                catch (Exception ex)
                {
                    lblWrongPIN.Text = ex.Message;
                    lblWrongPIN.Visible = true;
                } 
                
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cardNumber = this.DropDownListCards.SelectedItem.Value;
            // Make pin visible
            EnablePIN();
        }

        public void EnablePIN()
        {
            lblHeader.Text = "Kort Läst!";
            Button1.Visible = true;
            Button2.Visible = true;
            Button3.Visible = true;
            Button4.Visible = true;
            Button5.Visible = true;
            Button6.Visible = true;
            Button7.Visible = true;
            Button8.Visible = true;
            Button9.Visible = true;
            ButtonCancel.Visible = true;
            ButtonConfirm.Visible = true;

            // Remove the dropdown
            lblInsertCard.Visible = false;
            DropDownListCards.Visible = false;
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Useless
        }
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {

            Button1.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;
            Button5.Visible = false;
            Button6.Visible = false;
            Button7.Visible = false;
            Button8.Visible = false;
            Button9.Visible = false;
            ButtonCancel.Visible = false;
            ButtonConfirm.Visible = false;

            // Remove the dropdown
            lblInsertCard.Visible = true;
            DropDownListCards.Visible = true;

            lblWrongPIN.Visible = false;
            // Reset header label
            lblHeader.Text = "Ange din PIN-kod";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            PIN.Text += "1"; 
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PIN.Text += "2";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            PIN.Text += "3";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            PIN.Text += "4";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            PIN.Text += "5";
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            PIN.Text += "6";
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            PIN.Text += "7";
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            PIN.Text += "8";
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            PIN.Text += "9";
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            PIN.Text += "0";
        }

        protected void Backspace_Click(object sender, EventArgs e)
        {
            //Remove last number
            PIN.Text = PIN.Text.Substring(0, PIN.Text.Count() - 1);
        }
    }
}