using System;

namespace BankSystemProject
{
    public delegate void AccountNotificationHandler(string message); //خاص بالاشعارات

    public abstract class BankAccount : IBankAccount
    {
        public static int TotalAccounts 
        { get; private set; }

        private string _accountNumber;  // رقم الحساب مخزن بشكل خاص 
        private double _balance;  // الرصيد مخزن بشكل خاص 

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
        public event AccountNotificationHandler OnTransactionOccurred;   // يتم اطلاقه عند حدوث اي عملية مالية

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

        public void Deposit(double amount)  // عملية ايداع
        {
            if (amount > 0)
            {
                _balance += amount;
                Notify($"Deposit successful: {amount}. Current Balance: {_balance}"); // ارسال اشعار بعد الايداع
            }
        }

        public abstract void Withdraw(double amount);

        public double GetBalance() => _balance;
    }
}
