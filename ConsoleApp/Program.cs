// See https://aka.ms/new-console-template for more information
using Models;
using System.Linq;
namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Menu
            BankAccount[] bankAccounts = new BankAccount[2];
            int indexer = 0;
            bool choice = true;
            do
            {
                Console.Clear();
                BankAccountOptions();

                string option = Console.ReadLine();
                string title, code, accountType;
                BankAccount bankAccount=null;

                switch (option)
                {

                    case "1":
                        //Create new Account
                        Console.Clear();
                        Console.WriteLine("Enter Account Title:");
                        title = Console.ReadLine().Trim();

                        Console.WriteLine("Enter type for your account, Press 1) for Saving, Press 2) for Current");
                         accountType = Console.ReadLine().Trim();

                        if (accountType == "1")
                        {
                            bankAccount = new BankAccount(AccountType.Saving)
                            {
                                Title = title
                            };
                        }
                        else if (accountType == "2") 
                        {
                            bankAccount = new BankAccount(AccountType.Current)
                            {
                                Title = title
                            };
                        }

                        if (bankAccount !=null)
                        {
                            bankAccounts[indexer] = bankAccount;
                            indexer += 1;
                            Console.WriteLine("Account Created with account #:" + bankAccount.Code);
                        }
                        Console.WriteLine("Press any key for main menu...");
                        Console.ReadKey();
                        break;
                    case "2":
                        //Search an Account
                        Console.Clear();
                        Console.WriteLine("Enter Account number for searching....");
                        code = Console.ReadLine().Trim();

                        for (int i = 0; i < indexer; i++) {
                            if (string.Compare(bankAccounts[i].Code, code) == 0)
                            {
                                Console.WriteLine("-------------------------------------------");
                                Console.WriteLine("Account Number is: " + bankAccounts[i].Code);
                                Console.WriteLine("Account Title is: " + bankAccounts[i].Title);
                                Console.WriteLine("Account Type is: " + bankAccounts[i].AccountType);
                                Console.WriteLine("Account Status is: " + bankAccounts[i].AccountStatus);
                                Console.WriteLine("Account Balance is: " + bankAccounts[i].Balance);

                                Console.WriteLine("-------------------------------------------");
                                Console.ReadKey();
                            }
                        }

                        break;
                    case "3":
                        //loop through all the bank accounts
                        Console.Clear();
                        Console.WriteLine("List of Accounts with Details:");
                        if (indexer == 0)
                        {
                            Console.WriteLine("--------------");
                            Console.WriteLine("There is no data available");
                            Console.WriteLine("--------------");
                            break;
                        }
                        for (int i = 0; i < indexer; i++)
                        {

                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine("Account Number is: " + bankAccounts[i].Code);
                            Console.WriteLine("Account Title is: " + bankAccounts[i].Title);
                            Console.WriteLine("Account Type is: " + bankAccounts[i].AccountType);
                            Console.WriteLine("Account Status is: " + bankAccounts[i].AccountStatus);
                            Console.WriteLine("Account Balance is: " + bankAccounts[i].Balance);
                            Console.WriteLine("-------------------------------------------");
                        }
                            Console.ReadKey();
                        break;
                    case "4":
                        //widraw money
                        Console.WriteLine("Enter a account to withdraw money from");
                        code = Console.ReadLine();
                        for (int i = 0; i < bankAccounts.Length; i++)
                            if (bankAccounts[i].Code == code)
                            {
                                Console.WriteLine("Enter amount to withdraw from account");
                                decimal amountToWithdraw = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(bankAccounts[i].WithDraw(amountToWithdraw));
                            }
                        break;
                    case "5":
                        //payin money
                        Console.WriteLine("Enter a account to payin money to");
                        code = Console.ReadLine();
                        for (int i = 0; i < bankAccounts.Length; i++)
                            if (bankAccounts[i].Code == code)
                            {
                                Console.WriteLine("Enter amount to payin to account");
                                decimal amountToPayIn= Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(bankAccounts[i].PayIn(amountToPayIn));
                            }
                        break;
                    default:
                        choice = false;
                        break;
                }

            } while (choice);

            static void BankAccountOptions()
            {
                Console.WriteLine("1. Create new account");
                Console.WriteLine("2. Search an Account");
                Console.WriteLine("3. List All Accounts");
                Console.WriteLine("4. Withdraw money");
                Console.WriteLine("5. Pay In money");
                Console.WriteLine("0. Exit");
            }
        }
    }
}
