using System;
using BankyStuffLibrary;



namespace SuperBank
{
    class Program
    {
        static void Main(string[] args)
        {


            var account = new BankAccount("Kehinde", 10000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

            account.MakeWithdrawal(120, DateTime.Now, "For you");
            account.MakeWithdrawal(10, DateTime.Now, "For me");
            account.MakeWithdrawal(20, DateTime.Now, "For P");
            account.MakeWithdrawal(220, DateTime.Now, "For f");
            account.MakeWithdrawal(120, DateTime.Now, "For s");
            account.MakeWithdrawal(20, DateTime.Now, "For q");
            account.MakeWithdrawal(14, DateTime.Now, "For t");
            account.MakeWithdrawal(60, DateTime.Now, "For s");
            account.MakeWithdrawal(210, DateTime.Now, "For q");
            Console.WriteLine(account.Balance);


            Console.WriteLine(account.GetAccountHistory());

            var giftCard = new GiftCardAccount("gift card", 100, 50);
            giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
            giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
            giftCard.PerformMonthEndTransactions();
            // can make additional deposits:
            giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
            Console.WriteLine(giftCard.GetAccountHistory());

            var savings = new InterestEarningAccount("savings account", 10000);
            savings.MakeDeposit(750, DateTime.Now, "save some money");
            savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
            savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
            savings.PerformMonthEndTransactions();
            Console.WriteLine(savings.GetAccountHistory());

            var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
            // How much is too much to borrow?
            lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
            lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
            lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
            lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
            lineOfCredit.PerformMonthEndTransactions();
            Console.WriteLine(lineOfCredit.GetAccountHistory());

        }


    }
}
