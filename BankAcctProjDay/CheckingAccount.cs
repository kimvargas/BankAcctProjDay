using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAcctProjDay
{
    public class CheckingAccount:Account
    {

        private string acctType = "Checking";
        private decimal checkingBalance = 1000000.00m;

        public decimal CheckingBalance
        {
            get { return this.checkingBalance; }
        }

        public string AccountType
        {
            get { return this.acctType; }
        }
        

        public CheckingAccount()
        {
            this.checkingBalance = CheckingBalance;
            this.acctType = AccountType;

        }
    }
}
