﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bankomat2._0
{
    public partial class MainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Saldo_Click(object sender, EventArgs e)
        {
            Server.Transfer("SaldoPage.aspx");
        }

        protected void Uttag_Click(object sender, EventArgs e)
        {
            Server.Transfer("WithdrawalPage.aspx");
        }

        protected void Avbryt_Click(object sender, EventArgs e)
        {
            Server.Transfer("WelcomePage.aspx");
        }
    }
}