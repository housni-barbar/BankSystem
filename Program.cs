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
            // انشاء كائنات من انواع الحسابات المختلفة
            savings.OnTransactionOccurred += DisplayNotification;
            checking.OnTransactionOccurred += DisplayNotification;
            salary.OnTransactionOccurred += DisplayNotification;
            // اضافة الحسابات للقائمة الموحدة 
            myBank.Add(savings);
            myBank.Add(checking);
            myBank.Add(salary);

            Console.WriteLine("Smart Bank Management System");
            // للتحقق من صحة رقم الحساب 
            Console.WriteLine($"Is {savings.AccountNumber} valid {BankHelper.IsValidAccountNumber(savings.AccountNumber)}");
            Console.WriteLine("Start processing financial transactions via the menu.");
            // المرور على جميع الحسابات في البنك وتنفيذ عملية سحب تجريبية 200 لكل منهما
            foreach (var account in myBank)
            {
                Console.WriteLine($"Prossing : {account.GetBalance()}"); // طباعة الرصيد قبل العملية 
                account.Withdraw(200); // استدعاء دالة السحب 
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine("Press any key to exit....");
            Console.WriteLine($"\nGlobal Bank Info: Total Accounts in System: {BankAccount.TotalAccounts}");
            Console.ReadKey();

        }
        static void DisplayNotification(string message)
        {
            Console.WriteLine($"[NOTIFICATION]: {message}"); // عرض رسالة الاشعار 
        }
    }
}

