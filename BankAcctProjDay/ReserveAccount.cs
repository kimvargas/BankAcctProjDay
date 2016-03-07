using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAcctProjDay
{
    public class ReserveAccount:Account
    {

        private string acctType = "Reserve";
        private decimal reserveBalance = 5000.00m;

        public decimal ReserveBalance
        {
            get { return this.reserveBalance; }
        }

        public string AccountType
        {
            get { return this.acctType; }
        }
        
        public ReserveAccount()
        {
            this.reserveBalance = ReserveBalance;
            this.acctType = AccountType;
        }
    }
}
