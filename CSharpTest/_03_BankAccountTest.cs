using System;
using NUnit.Framework;
using MyBankTest;

[TestFixture]
public class BankAccountTest
{
    [Test]
    public void TestConstructor()
    {
        BankAccount account = new BankAccount("Account01", 1000);
        Assert.AreEqual(account.Balance, 1000);
    }

    [Test]
    public void TestDeposit()
    {
        BankAccount account = new BankAccount("Account01", 1000);
        account.Deposit(500);
        Assert.AreEqual(account.Balance, 1500);
    }

    [Test]
    public void TestDepositWithZeroAmount()
    {
        BankAccount account = new BankAccount("Account01", 1000);
        Assert.Throws<Exception>(() => account.Deposit(0));
    }

    [Test]
    public void TestDepositWithNegativeAmount()
    {
        BankAccount account = new BankAccount("Account01", 1000);
        Assert.Throws<Exception>(() => account.Deposit(-500));
    }

    [Test]
    public void TestWithdraw()
    {
        BankAccount account = new BankAccount("Account01", 1000);
        account.Withdraw(500);
        Assert.AreEqual(account.Balance, 500);
        account.Withdraw(200);
        Assert.AreEqual(account.Balance, 300);
    }

    [Test]
    public void TestWithdrawWithNegativeAmount()
    {
        BankAccount account = new BankAccount("Account01", 1000);
        Assert.Throws<Exception>(() => account.Withdraw(-500));
    }

    [Test]
    public void TestWithdrawOverAmountLimit()
    {
        BankAccount account = new BankAccount("Account01", 1000);
        Assert.Throws<Exception>(() => account.Withdraw(5000));
    }

    [Test]
    public void TestWithdrawWithZeroAmount()
    {
        BankAccount account = new BankAccount("Account01", 1000);
        Assert.Throws<Exception>(() => account.Withdraw(0));
    }
}