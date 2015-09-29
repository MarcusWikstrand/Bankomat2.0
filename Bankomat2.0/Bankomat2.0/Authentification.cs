using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class Authentification : iEvent
    {
        private int pin;

        public Authentification (int pin, int client, string description, bool outcome)
        {
            this.PIN = pin;
            Client = client;
            Description = description;
            Outcome = outcome;
        }

        public int Client
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime Time
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Outcome
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int PIN
        {
            get { return this.pin; }
            set { this.pin = value; }
        }

    }
}