using System;
using System.Collections.Generic;

namespace BankyStuffLibrary
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {

            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;

            }
        }

        private static int accountNumberSeed = 1234567890;



        private readonly decimal minimumBalance;

        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }

        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            this.Owner = name;
            this.minimumBalance = minimumBalance;
         
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
        }

        private List<Transaction> allTransactions = new List<Transaction>();

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);

        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount > 0)
            {
                var overdraftTransaction = checkWithdrawalLimit(Balance - amount < minimumBalance);
                var withdrawal = new Transaction(-amount, date, note);
                allTransactions.Add(withdrawal);
                if (overdraftTransaction != null)
                    allTransactions.Add(overdraftTransaction);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of Withdrawal must be positive");
            }
        }

        protected virtual Transaction? checkWithdrawalLimit(bool isOverdrawn)
        {
            if(isOverdrawn)
            {
                throw new InvalidOperationException("Not sufficient founds for this withdrawal");
            }
            else
            {
                return default;
            }
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.Append("Date\tAmount\tBalance\tNote\n");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.Append($"{item.Date.ToShortDateString()}\t{item.AmountForHuman}\t{balance}\t{item.Notes}\n");

            }
            return report.ToString();
        }

        public virtual void PerformMonthEndTransactions() { }

    }
}
