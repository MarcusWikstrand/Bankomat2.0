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
                try
                {
                    int amount = -300;
                    Console.WriteLine($"Balance before transaction " + atm.ViewConnectedAccountBalance());
                    Console.WriteLine($"Trying to withdraw {amount}:-");
                    atm.Withdraw(amount);
                    Console.WriteLine($"Balance after transaction " + atm.ViewConnectedAccountBalance());
            }
                catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            }

            List<String> latestTrans = atm.getFiveLatestTransactions("51425555555");
            latestTrans.ForEach(Console.WriteLine);
        }
    }
}
