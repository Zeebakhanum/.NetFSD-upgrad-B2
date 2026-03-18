using System;

class BankAccount
{
    // Private fields
    private int accountNumber;
    private double balance;

    // Property for Account Number
    public int AccountNumber
    {
        get { return accountNumber; }
        set { accountNumber = value; }
    }

    // Property for Balance (Read only outside)
    public double Balance
    {
        get { return balance; }
    }

    // Deposit Method
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine("Deposit Successful.");
            Console.WriteLine("Current Balance = " + balance);
        }
        else
        {
            Console.WriteLine("Invalid deposit amount.");
        }
    }

    // Withdraw Method
    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid withdrawal amount.");
        }
        else if (amount > balance)
        {
            Console.WriteLine("Insufficient Balance.");
        }
        else
        {
            balance -= amount;
            Console.WriteLine("Withdrawal Successful.");
            Console.WriteLine("Current Balance = " + balance);
        }
    }
}

class Program
{
    static void Main()
    {
        BankAccount acc = new BankAccount();

        acc.AccountNumber = 12345;

        // Sample Input
        acc.Deposit(5000);
        acc.Withdraw(2000);
    }
}