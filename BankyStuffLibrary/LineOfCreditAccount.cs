using System;
using System.Collections.Generic;
using System.Text;


namespace BankyStuffLibrary
{
    public class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
        {
        }

        public override void PerformMonthEndTransactions()
        {
            if(Balance < 0)
            {
                var interest = -Balance * 0.07m;
                MakeDeposit(interest, DateTime.Now, "Charge monthly interest");
            }
        }

        protected override Transaction checkWithdrawalLimit(bool isOverdrawn) =>
            isOverdrawn
            ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
            : default;

    }
}
