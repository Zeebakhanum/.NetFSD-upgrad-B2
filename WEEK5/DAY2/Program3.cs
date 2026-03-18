using System;

// 3. Custom Exception Class
public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message)
    {
    }
}

// 1. BankAccount Class
class BankAccount
{
    private double balance;

    // Constructor
    public BankAccount(double initialBalance)
    {
        balance = initialBalance;
    }

    // 2. Withdraw Method
    public void Withdraw(double amount)
    {
        if (amount > balance)
        {
            // 4. Throw custom exception
            throw new InsufficientBalanceException("Withdrawal amount exceeds available balance");
        }

        balance -= amount;
        Console.WriteLine("Withdrawal successful!");
        Console.WriteLine("Remaining Balance: " + balance);
    }
}

class Program3
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter Balance: ");
            double balance = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Withdrawal Amount: ");
            double withdrawAmount = Convert.ToDouble(Console.ReadLine());

            BankAccount account = new BankAccount(balance);

            // 5. Calling method (exception may occur here)
            account.Withdraw(withdrawAmount);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Invalid Input: " + ex.Message);
        }
        finally
        {
            // 6. Finally block
            Console.WriteLine("Transaction completed.");
        }

        Console.WriteLine("Program continues safely...");
    }
}