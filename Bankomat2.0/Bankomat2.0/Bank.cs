using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class Bank
    {
        //Bank identification code
        public string Bic { get; set; }
        // Bank namn
        public string Name { get; set; }

        Dictionary<string, Account> accounts;

        public List<iEvent> eventLog { get; set; }

        public void ConductTransaction()
        {

        }

        public void LogEvent()
        {

        }

        public void GetPerson(string SSN)
        {
            //SQL
        }
    }
}