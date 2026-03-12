using System;

class Calculator
{
    // Method for Addition
    public int Add(int a, int b)
    {
        return a + b;
    }

    // Method for Subtraction
    public int Subtract(int a, int b)
    {
        return a - b;
    }
}

class Program
{
    static void Main()
    {
        // Creating object of Calculator class
        Calculator calc = new Calculator();

        // Sample input
        int a = 10;
        int b = 5;

        // Calling methods
        int addition = calc.Add(a, b);
        int subtraction = calc.Subtract(a, b);

        // Display output
        Console.WriteLine("Addition = " + addition);
        Console.WriteLine("Subtraction = " + subtraction);
    }
}