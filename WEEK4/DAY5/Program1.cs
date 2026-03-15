using System;

class BankAccount
{
    // Private field
    private double balance;

    // Deposit method
    public void Deposit(double amount)
    {
        balance = balance + amount;
    }

    // Withdraw method
    public void Withdraw(double amount)
    {
        if (amount <= balance)
        {
            balance = balance - amount;
        }
        else
        {
            Console.WriteLine("Insufficient balance");
        }
    }

    // GetBalance method
    public double GetBalance()
    {
        return balance;
    }
}

class Program1
{
    static void Main()
    {
        BankAccount account = new BankAccount();

        account.Deposit(1000);
        account.Withdraw(300);

        Console.WriteLine("Current Balance = " + account.GetBalance());
    }
}