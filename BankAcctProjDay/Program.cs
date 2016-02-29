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
        static Account account1 = new Account();
        static decimal newbalance = account1.Balance;

        static void Main(string[] args)
        {

            string menu5 = "***** Account Summary *****\n\n";
            StreamWriter headerWriter = new StreamWriter(@"AccountSummary.txt");
            using (headerWriter)
            {
                headerWriter.WriteLine("*****************GRINGOTTS BANKING SYSTEM*****************");
                headerWriter.WriteLine("");
                headerWriter.WriteLine(menu5);
                headerWriter.WriteLine("");
                headerWriter.WriteLine("");
                headerWriter.WriteLine("Account Number\tWizard Name");
                headerWriter.WriteLine(client1.AcctNumber + "\t" + client1.Name);
                headerWriter.WriteLine("");
                headerWriter.WriteLine("");
                headerWriter.WriteLine("Date and Time\t\tTransaction\tBalance");
                headerWriter.WriteLine("");
            }
            Header();
            Menu();

            
        }

        static void Header()
        {
            Console.Clear();
            string header = "*****************GRINGOTTS BANKING SYSTEM*****************\n\n\n";
            Console.WriteLine(header);
        }

        static void Menu()
        {
            string menu = "1. View Wizard Info\n2. View Account Balance\n3. Deposit\n4. Withdraw\n5. View Account Summary\n6. Exit\n\nPlease select a number:";
            string menu1 = "***** Wizard Account ***** \n\n";
            string menu2 = "***** Account Balance ***** \n\n";
            string menu3 = "***** Deposits *****\n\n";
            string menu4 = "***** Withdrawls *****\n\n";
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
                    Console.WriteLine("\n\n" + "Account Number\t\tName\n\n" + client1.AcctNumber + "\t\t" + client1.Name);
                    Footer();

                    break;
                case 2:
                    Header();
                    Console.WriteLine(menu2);
                    Console.WriteLine("\n\n" + "Account Number\t\tWizard Name\t\tBalance\n\n" + client1.AcctNumber + "\t\t" + client1.Name + "\t\t" + newbalance);
                    Footer();

                    break;
                case 3:
                    Header();
                    Console.WriteLine(menu3);
                    Console.WriteLine("Enter Deposit Amount:");
                    
                    decimal deposit;
                    bool errorDeposit = decimal.TryParse(Console.ReadLine(), out deposit);

                    while (!errorDeposit)
                    {
                        Console.WriteLine("This is not a valid menu choice.");
                        errorDeposit = decimal.TryParse(Console.ReadLine(), out deposit);
                    }

                    newbalance = Account.Deposit(deposit, newbalance);
                    if (deposit.ToString().Length <= 6)
                    {
                        Console.WriteLine("\n\n" + "Account Number\tWizard Name\tTransaction\tBalance\n\n" + client1.AcctNumber + "\t" + client1.Name + "\t+" + deposit + "\t\t" + newbalance);
                    }
                    else
                    {
                        Console.WriteLine("\n\n" + "Account Number\tWizard Name\tTransaction\tBalance\n\n" + client1.AcctNumber + "\t" + client1.Name + "\t+" + deposit + "\t" + newbalance);
                    }
                    StreamWriter depositWriter = new StreamWriter(@"AccountSummary.txt",true);

                    using (depositWriter)
                    {
                        if (deposit.ToString().Length <= 6)
                        {
                            depositWriter.WriteLine(DateTime.Now + "\t+" + deposit + "\t\t" + newbalance);
                        } else
                        {
                            depositWriter.WriteLine(DateTime.Now +"\t+" + deposit + "\t" + newbalance);
                        }
                    }

                    Footer();
                    
                    break;
                case 4:

                    Header();
                    Console.WriteLine(menu4);
                    Console.WriteLine("Available Balance: " + newbalance + "\n");
                    Console.WriteLine("Enter Withdrawal Amount:");

                    decimal withdrawl;
                    bool errorWithdraw = decimal.TryParse(Console.ReadLine(), out withdrawl);

                    while (!errorWithdraw)
                    {
                        Console.WriteLine("This is not a valid menu choice.");
                        errorDeposit = decimal.TryParse(Console.ReadLine(), out withdrawl);
                    }

                    newbalance = Account.Withdraw(withdrawl, newbalance);

                    if (withdrawl.ToString().Length <= 6)
                    {
                        Console.WriteLine("\n\n" + "Account Number\tWizard Name\tTransaction\tBalance\n\n" + client1.AcctNumber + "\t" + client1.Name + "\t-" + withdrawl + "\t\t" + newbalance);
                    }
                    else
                    {
                        Console.WriteLine("\n\n" + "Account Number\tWizard Name\tTransaction\tBalance\n\n" + client1.AcctNumber + "\t" + client1.Name + "\t-" + withdrawl + "\t" + newbalance);
                    }
                    StreamWriter withdrawlWriter = new StreamWriter(@"AccountSummary.txt", true);
                    using (withdrawlWriter)
                    {
                        if (withdrawl.ToString().Length<=6)
                        {
                            withdrawlWriter.WriteLine(DateTime.Now + "\t-" + withdrawl + "\t\t" + newbalance);
                        }
                        else
                        {
                            withdrawlWriter.WriteLine(DateTime.Now + "\t-" + withdrawl + "\t" + newbalance);
                        }
                    }
                    Footer();
                    break;
                case 5:
                    Console.Clear();
                    StreamReader accountSummary = new StreamReader(@"AccountSummary.txt");
                    using (accountSummary)
                    {
                        Console.WriteLine(accountSummary.ReadToEnd());
                    }
                    Footer();
                    break;
                case 6:
                    Header(); 
                    Console.WriteLine("\n\n\nThank you for using Gringotts Banking System.\n\nHave a nice day.");
                    System.Threading.Thread.Sleep(1500);
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
