using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemProject
{
    public class SavingsAccount : BankAccount
    {
        private const double MinimumBalance = 100;
        public SavingsAccount (string accNo , double initialBalance)
            : base (accNo , initialBalance)
        {
        }
        public override void Withdraw(double amount)
        {
            if (amount > 0 && (Balance - amount) >= MinimumBalance)
            {
                Balance -= amount;
                Notify($"[Savings] Success! Withdrawn: {amount}. Remaining: {Balance}");
            }
            else
            {
                Notify($"[Savings] Transaction Denied! You must keep at least {MinimumBalance} in your balance.");
            }
        }
    }
}
