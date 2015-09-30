using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class Customer
    {
        List<PaymentCard> paymentCards;

        public Customer(string ssn, string firstName, string lastName)
        {
            paymentCards = new List<PaymentCard>();
            Ssn = ssn;
            FirstName = firstName;
            LastName = lastName;
        }

        public void ConnectPaymentCard(PaymentCard pc)
        {
            paymentCards.Add(pc);
        }

        public string Ssn { get; }
        public string FirstName { get; }
        public string LastName { get; }

        // Add a link to the actual PayCard that is linked to this person.
        public List<PaymentCard> PaymentCards { get; set; }
    }
}