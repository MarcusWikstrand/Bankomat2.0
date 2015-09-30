using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bankomat2._0
{
    public partial class WaitingPage : System.Web.UI.Page
    {

        List<String> quoteList = new List<string>()
        {
            "Hellre än rövare i poolen… -okänd.",
        "Be the change you want to see in the world. - Göran Isacson",
        "Say 'what' again, I dare you, I double dare you motherfucker, say 'what' one more Goddamn time!- Magnus Härenstam",
        "We have nothing to fear but fear itself. - Göran Isacson",
        "Use the force, Spock…- Ellen Ripley",
        "I fear not the man who has practiced 10,000 kicks once, but I fear the man who has practiced one kick 10,000 times.- Göran Isacson",
        "I never said that, it’s a made up quote. You should check Snopes.com more often.- Albert Einstein",
        "I got the rap patrol on the gat patrol, foes that wanna make sure my casket’s closed. \\n Rap critics that say he’s “Money Cash Hoes”, I’m from the hood stupid what type of facts are those?-  Prins Carl Philip."

        };

        protected void Page_Load(object sender, EventArgs e)
        {
            Random myRand = new Random();
            TextBoxQuote.Text = quoteList[myRand.Next(0, quoteList.Count - 1)];
        }
    }
}