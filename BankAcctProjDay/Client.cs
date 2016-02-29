using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAcctProjDay
{
    class Client
    {
        //Freaking Fields
        private string name = "Harry Potter";
        private string acctNumber = AccountNumber();

        //Freaking Properties
        public string Name
        {
            get { return this.name; }
        }

        public string AcctNumber
        {
            get { return this.acctNumber; }
        }

        //Freaking Method
        static string AccountNumber()
        {
            Random randomness = new Random();
            string acctNumber = randomness.Next(100000000, 999999999).ToString();
            return acctNumber;

        }

        //Freaking Constructor
        public Client()
        {
            this.name = "Harry Potter";
            this.acctNumber = AccountNumber();
        }
        
    }
}
