using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAcctProjDay
{
    class Program
    {
        static Client client1 = new Client();
        static CheckingAccount checkingAccount1 = new CheckingAccount();
        static decimal newCheckingBalance = checkingAccount1.CheckingBalance;

        static ReserveAccount reserveAccount1 = new ReserveAccount();
        static decimal newReserveBalance = reserveAccount1.ReserveBalance;
        
        static SavingsAccount savingsAccount1 = new SavingsAccount();
        static decimal newSavingsBalance = savingsAccount1.SavingsBalance;

        static string menu5 = "***** Checking Account Summary *****";
        static string menu6 = "***** Reserve Account Summary *****";
        static string menu7 = "***** Savings Account Summary *****";

        static void Main(string[] args)
        {
            AccountsPages();
            Header();
            Menu();
            
        }

        static void AccountsPages()
        {
            StreamWriter checkingHeaderWriter = new StreamWriter(@"CheckingAccountSummary.txt");
            using (checkingHeaderWriter)
            {
                checkingHeaderWriter.WriteLine($"*****************GRINGOTTS BANKING SYSTEM*****************\r\n\r\n{menu5}\r\n\r\n");
                checkingHeaderWriter.WriteLine("Account Number\tWizard Name");
                checkingHeaderWriter.WriteLine($"{ client1.CheckingAcctNumber }\t{ client1.Name}\r\n\r\n");
                checkingHeaderWriter.WriteLine("Date and Time\t\tTransaction\tBalance\r\n");
            }

            StreamWriter reserveHeaderWriter = new StreamWriter(@"ReserveAccountSummary.txt");
            using (reserveHeaderWriter)
            {
                reserveHeaderWriter.WriteLine($"*****************GRINGOTTS BANKING SYSTEM*****************\r\n\r\n{menu6}\r\n\r\n");
                reserveHeaderWriter.WriteLine("Account Number\tWizard Name");
                reserveHeaderWriter.WriteLine($"{ client1.ReserveAcctNumber }\t{ client1.Name}\r\n\r\n");
                reserveHeaderWriter.WriteLine("Date and Time\t\tTransaction\tBalance\r\n");
            }


            StreamWriter savingsHeaderWriter = new StreamWriter(@"SavingsAccountSummary.txt");
            using (savingsHeaderWriter)
            {
                savingsHeaderWriter.WriteLine($"*****************GRINGOTTS BANKING SYSTEM*****************\r\n\r\n{menu7}\r\n\r\n");
                savingsHeaderWriter.WriteLine("Account Number\tWizard Name");
                savingsHeaderWriter.WriteLine($"{ client1.SavingsAcctNumber }\t{ client1.Name}\r\n\r\n");
                savingsHeaderWriter.WriteLine("Date and Time\t\tTransaction\tBalance\r\n");
            }
        }


        static void Header()
        {
            Console.Clear();
            string header = "\n*****************GRINGOTTS BANKING SYSTEM*****************\n\n\n";
            Console.WriteLine(header);
        }

        static void Menu()
        {
            string menu = "1. View Wizard Info\n2. View Account Balance\n3. Deposit\n4. Withdraw\n5. View Account Summary\n6. Exit\n\nPlease select a number:";
            string menu1 = "***** Wizard Account ***** \n\n";
            string menu2 = "***** Account Balance ***** \n\n";
            string menu3 = "***** Deposits *****\n\nChoose an Account Type:\n1. Checking Account\n2. Reserve Account\n3. Savings Account\n";
            string menu4 = "***** Withdrawls *****\n\nChoose an Account Type:\n1. Checking Account\n2. Reserve Account\n3. Savings Account\n";
            Console.WriteLine(menu);
            int menuchoice;
            bool errorNumber = int.TryParse(Console.ReadLine(), out menuchoice);

            while (!errorNumber)
            {
                Console.WriteLine("This is not a valid menu choice.");
                errorNumber = int.TryParse(Console.ReadLine(), out menuchoice);
            }

            switch (menuchoice)
            {
                case 1:
                    Header();
                    Console.WriteLine(menu1);
                    Console.WriteLine($"\nClient Name: { client1.Name}\n\n\nClient Account Numbers\n\n"+
                        $"{ client1.CheckingAcctNumber }\t{checkingAccount1.AccountType}"+
                        $"\n{ client1.ReserveAcctNumber }\t{reserveAccount1.AccountType}"+
                        $"\n{ client1.SavingsAcctNumber }\t{savingsAccount1.AccountType}");
                    Footer();
                    break;

                case 2:
                    Header();
                    Console.WriteLine(menu2);
                    Console.WriteLine($"\n\nAccount Number\tAccount Type\tWizard Name\t\tBalance" + 
                        $"\n\n\n { client1.CheckingAcctNumber }\t{checkingAccount1.AccountType}\t{ client1.Name }\t\t{newCheckingBalance}" +
                        $"\n { client1.ReserveAcctNumber }\t{reserveAccount1.AccountType}\t\t{ client1.Name }\t\t{newReserveBalance}" +
                        $"\n { client1.SavingsAcctNumber }\t{savingsAccount1.AccountType}\t\t{ client1.Name }\t\t{newSavingsBalance}");
                    Footer();
                    break;

                case 3:
                    Header();
                    Console.WriteLine(menu3);
                    errorNumber = int.TryParse(Console.ReadLine(), out menuchoice);

                    while (!errorNumber)
                    {
                        Console.WriteLine("This is not a valid menu choice.");
                        errorNumber = int.TryParse(Console.ReadLine(), out menuchoice);
                    }

                    switch (menuchoice)
                    {
                        case 1:
                            Header();
                            Console.WriteLine(menu5);
                            Console.WriteLine("Enter Deposit Amount:");

                            decimal deposit;
                            bool errorDeposit = decimal.TryParse(Console.ReadLine(), out deposit);
                            Console.WriteLine("Deposit amount: " + string.Format("{0:C}", deposit));

                            while (!errorDeposit)
                            {
                                Console.Clear();
                                Console.WriteLine("\n\aPlease enter a valid monetary amount.\n");
                                Header();
                                Console.WriteLine(menu3);
                                Console.WriteLine("Enter Deposit Amount:");
                                errorDeposit = decimal.TryParse(Console.ReadLine(), out deposit);
                                Console.WriteLine("Deposit amount: " + string.Format("{0:C}", deposit));
                            }

                            newCheckingBalance = CheckingAccount.Deposit(deposit, newCheckingBalance);
                            if ((string.Format("{0:C}", deposit).Length <= 6))
                            {
                                Console.WriteLine($"\n\nAccount Number\tWizard Name\tTransaction\tBalance\n\n({client1.CheckingAcctNumber }\t{ client1.Name }\t+{ string.Format("{0:C}", deposit) }\t\t{string.Format("{0:C}", newCheckingBalance)}");
                            }
                            else
                            {
                                Console.WriteLine($"\n\nAccount Number\tWizard Name\tTransaction\tBalance\n\n{client1.CheckingAcctNumber}\t{client1.Name }\t+{ deposit }\t{ newCheckingBalance}");
                            }
                            StreamWriter checkingDepositWriter = new StreamWriter(@"CheckingAccountSummary.txt", true);

                            using (checkingDepositWriter)
                            {
                                if (deposit.ToString().Length <= 6)
                                {
                                    checkingDepositWriter.WriteLine($"{DateTime.Now }\t+{deposit }\t\t{ newCheckingBalance}");
                                }
                                else
                                {
                                    checkingDepositWriter.WriteLine($"{DateTime.Now }\t+{deposit }\t{ newCheckingBalance}");
                                }
                            }
                            break;

                        case 2:


                            Console.WriteLine("Enter Deposit Amount:");

                            errorDeposit = decimal.TryParse(Console.ReadLine(), out deposit);
                            Console.WriteLine(string.Format("{0:C}", deposit));

                            while (!errorDeposit)
                            {
                                Console.Clear();
                                Console.WriteLine("\n\aPlease enter a valid monetary amount.\n");
                                Header();
                                Console.WriteLine(menu3);
                                Console.WriteLine("Enter Deposit Amount:");
                                errorDeposit = decimal.TryParse(Console.ReadLine(), out deposit);
                            }

                            newReserveBalance = Account.Deposit(deposit, newReserveBalance);
                            if (deposit.ToString().Length <= 6)
                            {
                                Console.WriteLine($"\n\nAccount Number\tWizard Name\tTransaction\tBalance\n\n{client1.ReserveAcctNumber }\t{ client1.Name }\t+{ deposit }\t\t{newReserveBalance}");
                            }
                            else
                            {
                                Console.WriteLine($"\n\nAccount Number\tWizard Name\tTransaction\tBalance\n\n{client1.ReserveAcctNumber}\t{client1.Name }\t+{ deposit }\t{ newReserveBalance}");
                            }
                            StreamWriter reserveDepositWriter = new StreamWriter(@"ReserveAccountSummary.txt", true);

                            using (reserveDepositWriter)
                            {
                                if (deposit.ToString().Length <= 6)
                                {
                                    reserveDepositWriter.WriteLine($"{DateTime.Now }\t+{deposit }\t\t{ newReserveBalance}");
                                }
                                else
                                {
                                    reserveDepositWriter.WriteLine($"{DateTime.Now }\t+{deposit }\t{ newReserveBalance}");
                                }
                            }
                            break;

                        case 3:
                            
                            Console.WriteLine("Enter Deposit Amount:");
                            
                            errorDeposit = decimal.TryParse(Console.ReadLine(), out deposit);
                            Console.WriteLine(string.Format("{0:C}", deposit));

                            while (!errorDeposit)
                            {
                                Console.Clear();
                                Console.WriteLine("\n\aPlease enter a valid monetary amount.\n");
                                Header();
                                Console.WriteLine(menu3);
                                Console.WriteLine("Enter Deposit Amount:");
                                errorDeposit = decimal.TryParse(Console.ReadLine(), out deposit);
                            }

                            newSavingsBalance = Account.Deposit(deposit, newSavingsBalance);
                            if (deposit.ToString().Length <= 6)
                            {
                                Console.WriteLine($"\n\nAccount Number\tWizard Name\tTransaction\tBalance\n\n{client1.SavingsAcctNumber }\t{ client1.Name }\t+{ deposit }\t\t{newSavingsBalance }");
                            }
                            else
                            {
                                Console.WriteLine($"\n\nAccount Number\tWizard Name\tTransaction\tBalance\n\n{client1.SavingsAcctNumber}\t{client1.Name }\t+{ deposit }\t{ newSavingsBalance }");
                            }
                            StreamWriter savingsDepositWriter = new StreamWriter(@"SavingsAccountSummary.txt", true);

                            using (savingsDepositWriter)
                            {
                                if (deposit.ToString().Length <= 6)
                                {
                                    savingsDepositWriter.WriteLine($"{DateTime.Now }\t+{deposit }\t\t{ newSavingsBalance }");
                                }
                                else
                                {
                                    savingsDepositWriter.WriteLine($"{DateTime.Now }\t+{deposit }\t{ newSavingsBalance }");
                                }
                            }
                            break;

                        default:
                            break;
                    }

                    Footer();
                    
                    break;
                case 4:
                    Console.Clear();
                    Header();
                    Console.WriteLine(menu4);
                    errorNumber = int.TryParse(Console.ReadLine(), out menuchoice);

                    while (!errorNumber)
                    {
                        Console.WriteLine("This is not a valid menu choice.");
                        errorNumber = int.TryParse(Console.ReadLine(), out menuchoice);
                    }

                    switch (menuchoice)
                    {
                        case 1:
                            Console.WriteLine($"Available Balance: { newCheckingBalance }\n");
                            Console.WriteLine("Enter Withdrawal Amount:");

                            decimal withdrawl;
                            bool errorWithdraw = decimal.TryParse(Console.ReadLine(), out withdrawl);


                            while (!errorWithdraw)
                            {
                                Console.Clear();
                                Console.WriteLine("\n\aPlease enter a valid monetary amount.\n");
                                Header();
                                Console.WriteLine(menu4);
                                Console.WriteLine("Enter Withdrawal Amount:");
                                errorWithdraw = decimal.TryParse(Console.ReadLine(), out withdrawl);
                            }


                            newCheckingBalance = Account.Withdraw(withdrawl, newCheckingBalance);

                            if (withdrawl.ToString().Length <= 6)
                            {
                                Console.WriteLine($"\n\nAccount Number\tWizard Name\tTransaction\tBalance\n\n{client1.CheckingAcctNumber }\t{ client1.Name }\t+{ withdrawl }\t\t{newCheckingBalance}");
                            }
                            else
                            {
                                Console.WriteLine($"\n\nAccount Number\tWizard Name\tTransaction\tBalance\n\n{client1.CheckingAcctNumber}\t{client1.Name }\t+{ withdrawl }\t{ newCheckingBalance}");
                            }
                            StreamWriter checkingWithdrawlWriter = new StreamWriter(@"CheckingAccountSummary.txt", true);
                            using (checkingWithdrawlWriter)
                            {
                                if (withdrawl.ToString().Length <= 6)
                                {
                                    checkingWithdrawlWriter.WriteLine($"{DateTime.Now }\t-{ withdrawl }\t\t{ newCheckingBalance}");
                                }
                                else
                                {
                                    checkingWithdrawlWriter.WriteLine($"{DateTime.Now }\t-{ withdrawl }\t{ newCheckingBalance}");
                                }
                            }

                            break;

                        case 2:
                            Console.WriteLine($"Available Balance: { newReserveBalance }\n");
                            Console.WriteLine("Enter Withdrawal Amount:");
                            
                            errorWithdraw = decimal.TryParse(Console.ReadLine(), out withdrawl);


                            while (!errorWithdraw)
                            {
                                Console.Clear();
                                Console.WriteLine("\n\aPlease enter a valid monetary amount.\n");
                                Header();
                                Console.WriteLine(menu4);
                                Console.WriteLine("Enter Withdrawal Amount:");
                                errorWithdraw = decimal.TryParse(Console.ReadLine(), out withdrawl);
                            }


                            newReserveBalance = Account.Withdraw(withdrawl, newReserveBalance);

                            if (withdrawl.ToString().Length <= 6)
                            {
                                Console.WriteLine($"\n\nAccount Number\tWizard Name\tTransaction\tBalance\n\n{client1.ReserveAcctNumber }\t{ client1.Name }\t+{ withdrawl }\t\t{newReserveBalance}");
                            }
                            else
                            {
                                Console.WriteLine($"\n\nAccount Number\tWizard Name\tTransaction\tBalance\n\n{client1.ReserveAcctNumber}\t{client1.Name }\t+{ withdrawl }\t{ newReserveBalance}");
                            }
                            StreamWriter reserveWithdrawlWriter = new StreamWriter(@"ReserveAccountSummary.txt", true);
                            using (reserveWithdrawlWriter)
                            {
                                if (withdrawl.ToString().Length <= 6)
                                {
                                    reserveWithdrawlWriter.WriteLine($"{DateTime.Now }\t-{ withdrawl }\t\t{ newReserveBalance}");
                                }
                                else
                                {
                                    reserveWithdrawlWriter.WriteLine($"{DateTime.Now }\t-{ withdrawl }\t{ newReserveBalance}");
                                }
                            }

                            break;

                        case 3:
                            Console.WriteLine($"Available Balance: { newSavingsBalance }\n");
                            Console.WriteLine("Enter Withdrawal Amount:");

                          errorWithdraw = decimal.TryParse(Console.ReadLine(), out withdrawl);


                            while (!errorWithdraw)
                            {
                                Console.Clear();
                                Console.WriteLine("\n\aPlease enter a valid monetary amount.\n");
                                Header();
                                Console.WriteLine(menu4);
                                Console.WriteLine("Enter Withdrawal Amount:");
                                errorWithdraw = decimal.TryParse(Console.ReadLine(), out withdrawl);
                            }


                            newSavingsBalance = Account.Withdraw(withdrawl, newSavingsBalance);

                            if (withdrawl.ToString().Length <= 6)
                            {
                                Console.WriteLine($"\n\nAccount Number\tWizard Name\tTransaction\tBalance\n\n{client1.SavingsAcctNumber }\t{ client1.Name }\t+{ withdrawl }\t\t{newSavingsBalance}");
                            }
                            else
                            {
                                Console.WriteLine($"\n\nAccount Number\tWizard Name\tTransaction\tBalance\n\n{client1.SavingsAcctNumber}\t{client1.Name }\t+{ withdrawl }\t{ newSavingsBalance}");
                            }
                            StreamWriter savingsWithdrawlWriter = new StreamWriter(@"SavingsAccountSummary.txt", true);
                            using (savingsWithdrawlWriter)
                            {
                                if (withdrawl.ToString().Length <= 6)
                                {
                                    savingsWithdrawlWriter.WriteLine($"{DateTime.Now }\t-{ withdrawl }\t\t{ newSavingsBalance}");
                                }
                                else
                                {
                                    savingsWithdrawlWriter.WriteLine($"{DateTime.Now }\t-{ withdrawl }\t{ newSavingsBalance}");
                                }
                            }

                            break;
                    }


                    
                    Footer();
                    break;
                case 5:
                    Console.Clear();
                    Header();
                    Console.WriteLine(menu4);
                    errorNumber = int.TryParse(Console.ReadLine(), out menuchoice);

                    while (!errorNumber)
                    {
                        Console.WriteLine("This is not a valid menu choice.");
                        errorNumber = int.TryParse(Console.ReadLine(), out menuchoice);
                    }

                    switch (menuchoice)
                    {
                        case 1:
                            StreamReader checkingAccountSummary = new StreamReader(@"CheckingAccountSummary.txt");
                            using (checkingAccountSummary)
                            {
                                Console.Clear();
                                Console.WriteLine(checkingAccountSummary.ReadToEnd());
                            }
                            break;
                        case 2:
                            StreamReader reserveAccountSummary = new StreamReader(@"ReserveAccountSummary.txt");
                            using (reserveAccountSummary)
                            {
                                Console.Clear();
                                Console.WriteLine(reserveAccountSummary.ReadToEnd());
                            }
                            break;
                        case 3:
                            StreamReader savingsAccountSummary = new StreamReader(@"SavingsAccountSummary.txt");
                            using (savingsAccountSummary)
                            {
                                Console.Clear();
                                Console.WriteLine(savingsAccountSummary.ReadToEnd());
                            }
                            break;
                    }
                    
                    Footer();
                    break;
                case 6:
                    Header(); 
                    Console.WriteLine("\n\n\nThank you for using GRINGOTTS BANKING SYSTEM.\n\nHave a nice day.");
                    System.Threading.Thread.Sleep(1250);
                    return;
                    
                default:
                    break;
            }
            
        }

        

        static void Footer()
        {
            Console.WriteLine("\n\n\nHit any key to return to main menu.");
            Console.ReadKey();
            Console.Clear();
            Header();
            Menu();
        }
    }
}
