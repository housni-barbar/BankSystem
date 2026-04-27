using System;

namespace BankSystemProject
{
    public delegate void AccountNotificationHandler(string message);

    public abstract class BankAccount : IBankAccount
    {
        public static int TotalAccounts { get; private set; }

        private string _accountNumber;
        private double _balance;

        public string AccountNumber
        {
            get { return _accountNumber; }
            private set { _accountNumber = value; }
        }

        public double Balance
        {
            get { return _balance; }
            protected set { _balance = value; }
        }
        public event AccountNotificationHandler OnTransactionOccurred;

        public BankAccount(string accNo, double initialBalance)
        {
            _accountNumber = accNo;
            _balance = initialBalance;

            TotalAccounts++;
        }

        protected void Notify(string message)
        {
            OnTransactionOccurred?.Invoke(message);
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                _balance += amount;
                Notify($"Deposit successful: {amount}. Current Balance: {_balance}");
            }
        }

        public abstract void Withdraw(double amount);

        public double GetBalance() => _balance;
    }
}