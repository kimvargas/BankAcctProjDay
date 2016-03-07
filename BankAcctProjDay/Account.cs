using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAcctProjDay
{
    public class Account
    {
        string name = "Harry Potter";
        decimal balance = 1000000.00m;

        public decimal Balance
        {
            get { return this.balance; }
        }

        public string Name
        {
            get { return this.name; }
        }

        //Method - WD
        public static decimal Withdraw(decimal wd, decimal currentBalance)
        {
            decimal newBalance = currentBalance - wd;
            
            return newBalance;
        }
        //Method - DEP
        public static decimal Deposit(decimal dep, decimal currentBalance)
        {
            decimal newBalance = currentBalance + dep;
            return newBalance;
        }

        public Account()
        {
            this.balance = Balance;
            
        }













    }
}
