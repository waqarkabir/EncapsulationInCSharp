// See https://aka.ms/new-console-template for more information
using Models;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Menu
            BankAccount[] bankAccounts = new BankAccount[10];
            bool choice = true;
            do
            {

                Console.WriteLine("1. Create");


                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        // input all data
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    default:
                        choice = false;
                        break;
                }

            } while (choice);
        }
    }
}
