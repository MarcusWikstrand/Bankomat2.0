using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATMProject._0
{
    public class Banknote
    {
        public Banknote(int denomination)
        {
            Denomination = denomination;
        }

        //Sedeltyp (100 eller 500 kronor)
        public int Denomination { get; private set; }
    }
}