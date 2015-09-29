using Bankomat2._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            ATM atm = new ATM(1337);

            bool authResult = atm.Authenticate("51425555555", 1111);
            Console.WriteLine(@"Login attempt, Outcome: {authResult}");

            if (authResult == true)
            {
                Console.WriteLine("Trying to withdraw 100:-");
                atm.Withdraw(100);
            }
        }
    }
}
