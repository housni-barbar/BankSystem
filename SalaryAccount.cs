using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemProject
{
    public class SalaryAccount : BankAccount
    {
        private const double SalaryBonus = 10; // تعريف مكافاة ثابته تضاف عند ايداع الراتب قيمتها 10
        public SalaryAccount(string accNO, double initialBalance)
            : base(accNO, initialBalance)
        {
        }
        public override void Withdraw(double amount)
        {
           if (amount > 0 && Balance >= amount) // التحقق ان المبلغ المطلوب سحبه متوفر في الرصيد
            {
                Balance -= amount; // طرح المبلغ من الرصيد الحالي
                Notify($"[Salary] Success! Withdrawn: {amount}. New Balance: {Balance}"); // ارسال اشعار بنجاح العملية وعرض الرصيد المتبقي
            }
           else
            {
                Notify("[Salary] Denied! You cannot withdraw more than your current balance."); // محاولة سحب مبلغ اكبر من الرصيد يتم رفض العملية
            }
        }
        public void DepositSalary(double amount)
        {
            double finalAmount = amount + SalaryBonus; // حساب المبلغ النهائي + المكافاة
            Deposit(finalAmount); // نستخدم دالة الإيداع الأصلية من الأب
            Console.WriteLine($"[Salary] Salary deposited with a bonus of {SalaryBonus}!"); // طباعة رسالة ايداع الراتب مع المكافاة
        }
    }
}
