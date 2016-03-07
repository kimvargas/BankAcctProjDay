using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAcctProjDay
{
    public class SavingsAccount:Account
    {

        private string acctType = "Savings";
        private decimal savingsBalance = 10000.00m;

        public decimal SavingsBalance
        {
            get { return this.savingsBalance; }
        }

        public string AccountType
        {
            get { return this.acctType; }
        }
        
        public SavingsAccount()
        {
            this.savingsBalance = SavingsBalance;
            this.acctType = AccountType;
        }

    }
}
