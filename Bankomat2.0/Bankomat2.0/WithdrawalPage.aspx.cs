using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bankomat2._0
{
    public partial class WithdrawalPage : System.Web.UI.Page
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
            Server.Transfer("SaldoPage.aspx");
        }

        protected void Add100_Click(object sender, ImageClickEventArgs e)
        {
            int saldo = int.Parse(this.SaldoVisning.Text);
            saldo += 100;
            this.SaldoVisning.Text = saldo.ToString();
        }

        protected void Add500_Click(object sender, ImageClickEventArgs e)
        {
            int saldo = int.Parse(this.SaldoVisning.Text);
            saldo += 500;
            this.SaldoVisning.Text = saldo.ToString();
        }

        protected void Reduce100_Click(object sender, ImageClickEventArgs e)
        {
            int saldo = int.Parse(this.SaldoVisning.Text);
            saldo -= 100;
            this.SaldoVisning.Text = saldo.ToString();
        }

        protected void Reduce500_Click(object sender, ImageClickEventArgs e)
        {
            int saldo = int.Parse(this.SaldoVisning.Text);
            saldo -= 500;
            this.SaldoVisning.Text = saldo.ToString();
        }

        protected void TagUtSumma_Click(object sender, EventArgs e)
        {
            try
            {
                atm.Withdraw(int.Parse(this.SaldoVisning.Text));
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}