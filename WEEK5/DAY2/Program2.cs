using System;

class Calculator
{
    // Method for division
    public void Divide(int numerator, int denominator)
    {
        try
        {
            int result = numerator / denominator;
            Console.WriteLine("Result: " + result);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Cannot divide by zero");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Operation completed safely");
        }
    }
}

class Program2
{
    static void Main(string[] args)
    {
        Calculator calc = new Calculator();

        Console.Write("Enter Numerator: ");
        int num = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Denominator: ");
        int den = Convert.ToInt32(Console.ReadLine());

        calc.Divide(num, den);

        // Program continues after error
        Console.WriteLine("Program is still running...");
    }
}