using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemProject
{
    public class SalaryAccount : BankAccount
    {
        private const double SalaryBonus = 10;
        public SalaryAccount(string accNO, double initialBalance)
            : base(accNO, initialBalance)
        {
        }
        public override void Withdraw(double amount)
        {
           if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                Notify($"[Salary] Success! Withdrawn: {amount}. New Balance: {Balance}");
            }
           else
            {
                Notify("[Salary] Denied! You cannot withdraw more than your current balance.");
            }
        }
        public void DepositSalary(double amount)
        {
            double finalAmount = amount + SalaryBonus;
            Deposit(finalAmount); // نستخدم دالة الإيداع الأصلية من الأب
            Console.WriteLine($"[Salary] Salary deposited with a bonus of {SalaryBonus}!");
        }
    }
}
