using System;
using BankyStuffLibrary;
using Xunit;


namespace BankyTests
{
    public class BasicTest
    {
        [Fact]
        public void CheckTest()
        {
            Assert.True(true);
        }
        [Fact]
        public void CantTakeMoreThanYouHave()
        {
            var account = new BankAccount("Kehinde", 10000);
            Assert.Throws<InvalidOperationException>(
                () => account.MakeWithdrawal(75000,
                                DateTime.Now,
                                 "For you")
            );
        }

        [Fact]
        public void CantDepositNegativeAmount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                ()=>  new BankAccount("Invalid", -55)
                );
        }
    }
}
