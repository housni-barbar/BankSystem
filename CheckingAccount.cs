using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemProject
{
    public class CheckingAccount : BankAccount
    {
        private const double TransactionFee = 1.5; //تعريف ثابت لعمولة السحب وهي 1.5
        public CheckingAccount(string accNo, double initialBalance)
            : base(accNo, initialBalance)
        {
        }
        public override void Withdraw(double amount)
        {
            double totalAmount = amount + TransactionFee;
            if (amount > 0 && Balance >= totalAmount) //التحقق ان المبلغ المطلوب اكبر من الصفر
            {
                Balance -= totalAmount; //خصم المبلغ الاجمالي من الرصيد
                Notify($"[Checking] Success! Withdrawn: {amount} + Fee: {TransactionFee}. New Balance: {Balance}"); //ارسال اشعار بنجاح العملية مع تفاصيل الخصم والرصيدالجديد
            }
            else
            {
                Notify("[Checking] Denied! Insufficient balance to cover the amount and the transaction fee."); //في حال عدم كفاية الرصيد يتم ارسال اشعار برفض العملية
            }
        }
    }
}
