using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountExample
{
    internal class Program
    {
        static List<BankAccount> bankAccounts = new List<BankAccount>();

        public static void Create(int id)
        {
            var existingbankAccount = bankAccounts.Where(b => b.Id == id).FirstOrDefault();
            if(existingbankAccount != null)
            {
                Console.WriteLine("Account already exists!");
            }
            else
            {
                var acc = new BankAccount();
                acc.Id = id;
                bankAccounts.Add(acc);
            }
        }

        public static void Deposit(int id, double amount)
        {
            var existingbankAccount = bankAccounts.Where(b => b.Id == id).FirstOrDefault();
            if (existingbankAccount == null)
            {
                Console.WriteLine("Account doesn't exists!");
            }
            else
            {
                existingbankAccount.Amount += amount;
            }
        }

        public static void Withdraw(int id, double amount)
        {
            var existingbankAccount = bankAccounts.Where(b => b.Id == id).FirstOrDefault();
            if (existingbankAccount == null)
            {
                Console.WriteLine("Account doesn't exists!");
            }
            else
            {
                if(existingbankAccount.Amount >= amount)
                {
                    existingbankAccount.Amount -= amount;
                }
                else
                {
                    Console.WriteLine("Insufficient balance");
                }
            }
        }

        public static void Print(int id)
        {
            var existingbankAccount = bankAccounts.Where(b => b.Id == id).FirstOrDefault();
            if (existingbankAccount == null)
            {
                Console.WriteLine("Account doesn't exists!");
            }
            else
            {
                Console.WriteLine("Account ID"+ existingbankAccount.Id + 
                    ", balance " + String.Format("{0:0.00}", existingbankAccount.Amount));
            }
        }

        static void Main(string[] args)
        {
            //Create 1
            string command = Console.ReadLine();
            while(command != "End")
            {
                var cmdArgs = command.Split(' ');
                var cmdType = cmdArgs[0];
                switch(cmdType)
                {
                    case "Create":
                        Create(int.Parse(cmdArgs[1]));
                        break;
                    case "Deposit":
                        Deposit(int.Parse(cmdArgs[1]), double.Parse(cmdArgs[2]));
                        break;
                    case "Withdraw":
                        Withdraw(int.Parse(cmdArgs[1]), double.Parse(cmdArgs[2]));
                        break;
                    case "Print":
                        Print(int.Parse(cmdArgs[1]));
                        break;
                    default:
                        Console.WriteLine("Error! Wrong Command");
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
