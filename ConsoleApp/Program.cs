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
            bool choice = true;
            int indexer = 0;
            do
            {
                BankAccountOptions();

                string option = Console.ReadLine();
                int code;
                switch (option)
                {

                    case "1":
                        //Create new Account
                        Console.WriteLine("Enter Account Name:");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter type for your account, Press 0 for Saving, Press 1 for Current");
                        var accountType = Console.ReadLine();
                        var at = AccountType.Current;
                        if (accountType == "0")
                        {
                            at = AccountType.Saving;
                        }
                        BankAccount bankAccount = new BankAccount(at);
                        bankAccount.Title = title;
                        bankAccounts[indexer] = bankAccount;
                        indexer++;
                        Console.Clear();
                        break;
                    case "2":
                        //loop through all the bank accounts
                        Console.WriteLine("List of Accounts with Details:");
                        if (indexer == 0)
                        {
                            Console.WriteLine("There is not data");
                            Console.WriteLine("--------------");
                            break;
                        }
                        for (int i = 0; i < bankAccounts.Length; i++)
                        {
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine("Account Number is: " + bankAccounts[i].Code);
                            Console.WriteLine("Account Title is: " + bankAccounts[i].Title);
                            Console.WriteLine("Account Type is: " + bankAccounts[i].AccountType);
                            Console.WriteLine("Account Status is: " + bankAccounts[i].AccountStatus);
                            Console.WriteLine("Account Balance is: " + bankAccounts[i].Balance);
                            Console.WriteLine("-------------------------------------------");
                        }
                        break;
                    case "3":
                        //Search an Account
                        Console.Clear();
                        Console.WriteLine("Enter Account number for searching....");
                        code = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < bankAccounts.Length; i++)
                            if (bankAccounts[i].Code == code)
                            {
                                Console.WriteLine("-------------------------------------------");
                                Console.WriteLine("Account Number is: " + bankAccounts[i].Code);
                                Console.WriteLine("Account Title is: " + bankAccounts[i].Title);
                                Console.WriteLine("Account Type is: " + bankAccounts[i].AccountType);
                                Console.WriteLine("Account Status is: " + bankAccounts[i].AccountStatus);
                                Console.WriteLine("Account Balance is: " + bankAccounts[i].Balance);

                                Console.WriteLine("-------------------------------------------");
                            }

                        break;
                    case "4":
                        //widraw money
                        Console.WriteLine("Enter a account to withdraw money from");
                        code = Convert.ToInt32(Console.ReadLine());
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
                        code = Convert.ToInt32(Console.ReadLine());
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
                Console.WriteLine("2. List All Accounts");
                Console.WriteLine("3. Search an Account");
                Console.WriteLine("4. Withdraw money");
                Console.WriteLine("5. Pay In money");
                Console.WriteLine("0. Exit");
            }
        }
    }
}
