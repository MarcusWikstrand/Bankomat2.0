using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bankomat2._0
{
    public partial class ReceiptPage : System.Web.UI.Page
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
    }
}