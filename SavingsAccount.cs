using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemProject
{
    public class SavingsAccount : BankAccount
    {
        private const double MinimumBalance = 100; // لا تعريف ثابت لا يسمح للعميل بسحب مبلغ يجعل رصيده اقل من 100
        public SavingsAccount (string accNo , double initialBalance)
            : base (accNo , initialBalance)
        {
        }
        public override void Withdraw(double amount)
        {
            if (amount > 0 && (Balance - amount) >= MinimumBalance) // يجب ان يكون المبلغ اكبر من ال 0 وان يكزن الرصيد بعد السحب اكبر او يساوي ال 100
            {
                Balance -= amount; // تنفيذ عملية الخصم من الرصيد 
                Notify($"[Savings] Success! Withdrawn: {amount}. Remaining: {Balance}"); // اشعار بنجاح العملية وعرض الرصيد الحالي
            }
            else
            {
                Notify($"[Savings] Transaction Denied! You must keep at least {MinimumBalance} in your balance."); // في حال كان الرصيد اقل من 100 سيتم رفض العملية وابلاغ المستخدم بالسبب 
            }
        }
    }
}
