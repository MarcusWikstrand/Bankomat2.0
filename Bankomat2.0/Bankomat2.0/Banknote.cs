using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class Banknote
    {
        public Banknote(int denomination)
        {
            Denomination = denomination;
        }

        //GLÖM INTE ATT TA BORT serialNumber från UML!
        //Sedeltyp (100 eller 500 kronor)
        public int Denomination { get; private set; }
    }
}