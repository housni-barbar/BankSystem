using System;
using System.Collections.Generic;
namespace BankSystemProject
{
    public interface IBankAccount
    {
        void Deposit(double amount); // ايداع
        void Withdraw(double amount);  // سحب
        double GetBalance(); // الحصول على الرصيد
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<IBankAccount> myBank = new List<IBankAccount>();
            var savings = new SavingsAccount("ACC-Savings_Ahmad", 1500);
            var checking = new CheckingAccount("ACC-Business_Checking", 500);
            var salary = new SalaryAccount("ACC-Monthly_Salary", 3000);

            savings.OnTransactionOccurred += DisplayNotification;
            checking.OnTransactionOccurred += DisplayNotification;
            salary.OnTransactionOccurred += DisplayNotification;

            myBank.Add(savings);
            myBank.Add(checking);
            myBank.Add(salary);

            Console.WriteLine("Smart Bank Management System");

            Console.WriteLine($"Is {savings.AccountNumber} valid {BankHelper.IsValidAccountNumber(savings.AccountNumber)}");
            Console.WriteLine("Start processing financial transactions via the menu.");

            foreach (var account in myBank)
            {
                Console.WriteLine($"Prossing : {account.GetBalance()}");
                account.Withdraw(200);
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine("Press any key to exit....");
            Console.WriteLine($"\nGlobal Bank Info: Total Accounts in System: {BankAccount.TotalAccounts}");
            Console.ReadKey();

        }
        static void DisplayNotification(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[NOTIFICATION]: {message}");
            Console.ResetColor();
        }
    }
}

