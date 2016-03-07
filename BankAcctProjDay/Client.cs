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
        private string checkingAcctNumber = AccountNumber(omg);
        private string reserveAcctNumber = AccountNumber(omg);
        private string savingsAcctNumber = AccountNumber(omg);

        static string omg = "omg";

        //Freaking Properties
        public string Name
        {
            get { return this.name; }
        }

        public string CheckingAcctNumber
        {
            get { return this.checkingAcctNumber; }
        }
        public string ReserveAcctNumber
        {
            get { return this.reserveAcctNumber; }
        }
        public string SavingsAcctNumber
        {
            get { return this.savingsAcctNumber; }
        }
        //Freaking Method
        static string AccountNumber(string newAcctNumber)
        {
            Random randomness = new Random();
            newAcctNumber = randomness.Next(100000000, 999999999).ToString();
            return newAcctNumber;

        }

        //Freaking Constructor
        public Client()
        {
            this.name = "Harry Potter";
            this.checkingAcctNumber = AccountNumber(omg);
            this.reserveAcctNumber = AccountNumber(omg);
            this.savingsAcctNumber = AccountNumber(omg);

        }

    }
}
