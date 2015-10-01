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
        public string cardNumber = "";
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
            //PIN.Visible = false;
            //Button1.Visible = false;
            //Button2.Visible = false;
            //Button3.Visible = false;
            //Button4.Visible = false;
            //Button5.Visible = false;
            //Button6.Visible = false;
            //Button7.Visible = false;
            //Button8.Visible = false;
            //Button9.Visible = false;
            //Button10.Visible = false;
            //ButtonHashtag.Visible = false;
            //ButtonCancel.Visible = false;
            //ButtonConfirm.Visible = false;
            //Backspace.Visible = false;
            ////  dropdown
            //lblInsertCard.Visible = true;
            //DropDownListCards.Visible = true;
            //lblWrongPIN.Visible = false;
            //// Reset header label
            //lblHeader.Text = "Ange din PIN-kod";
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            // Mke sure we have udated ATM
            Session["ATM"] = atm;
            try
            {
                string pinint = (string)Session["enteredPIN"];
                int pinstring = int.Parse(pinint);
                atm.Authenticate(Session["cardNumber"].ToString(), pinstring); 
                // Mke sure we have udated ATM
                Session["ATM"] = atm;
                // Gå vidare till
                Server.Transfer("MainMenu.aspx");
            }
            catch (Exception ex)
            {
                lblWrongPIN.Text = ex.Message;
                lblWrongPIN.Visible = true;
            }


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Session["cardNumber"] = this.DropDownListCards.SelectedItem.Value.ToString();
            // Make pin visible
            EnablePIN();
        }
        public void EnablePIN()
        {
            PIN.Visible = true;
            lblHeader.Text = "Kort Läst - Succé! Fyll nu i din PIN-kod för att logga in!";
            lblHeader.Visible = true;
            Button1.Visible = true;
            Button2.Visible = true;
            Button3.Visible = true;
            Button4.Visible = true;
            Button5.Visible = true;
            Button6.Visible = true;
            Button7.Visible = true;
            Button8.Visible = true;
            Button9.Visible = true;
            Button10.Visible = true;
            ButtonCancel.Visible = true;
            ButtonConfirm.Visible = true;
            Backspace.Visible = true;

            // Remove the dropdown
            lblInsertCard.Visible = false;
            DropDownListCards.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            ButtonHashtag.Visible = true;

        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Session["enteredPIN"] += PIN.Text.Substring(PIN.Text.Count() -1);
            int numofchars = PIN.Text.Count();
            PIN.Text = "";
            for (int i = 0; i < numofchars; i++)
            {
                PIN.Text += "*";
            }
        }
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            PIN.Visible = false;
            Button1.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;
            Button5.Visible = false;
            Button6.Visible = false;
            Button7.Visible = false;
            Button8.Visible = false;
            Button9.Visible = false;
            Button10.Visible = false;
            ButtonHashtag.Visible = true;
            ButtonCancel.Visible = false;
            ButtonConfirm.Visible = false;
            Backspace.Visible = false;
            //  dropdown
            lblInsertCard.Visible = true;
            DropDownListCards.Visible = true;
            lblWrongPIN.Visible = false;
            // Reset header label
            lblHeader.Text = "Ange din PIN-kod";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            PIN.Text += "1";
            TextBox1_TextChanged(sender, e);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PIN.Text += "2";
            TextBox1_TextChanged(sender, e);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            PIN.Text += "3";
            TextBox1_TextChanged(sender, e);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            PIN.Text += "4";
            TextBox1_TextChanged(sender, e);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            PIN.Text += "5";
            TextBox1_TextChanged(sender, e);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            PIN.Text += "6";
            TextBox1_TextChanged(sender, e);
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            PIN.Text += "7";
            TextBox1_TextChanged(sender, e);
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            PIN.Text += "8";
            TextBox1_TextChanged(sender, e);
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            PIN.Text += "9";
            TextBox1_TextChanged(sender, e);
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            PIN.Text += "0";
            TextBox1_TextChanged(sender, e);
        }

        protected void Backspace_Click(object sender, EventArgs e)
        {
            //Remove last number
            PIN.Text = PIN.Text.Substring(0, PIN.Text.Count() - 1);
            TextBox1_TextChanged(sender, e);
        }

        protected void MakeItSo_Click(object sender, EventArgs e)
        {
            Session["cardNumber"] = this.DropDownListCards.SelectedItem.Value.ToString();
            // Make pin visible
            EnablePIN();

        }
    }
}