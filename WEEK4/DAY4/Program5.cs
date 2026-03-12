using System;

class PowerCalculator
{
    // Recursive method
    public int CalculatePower(int baseNum, int exponent)
    {
        // Base case
        if (exponent == 0)
            return 1;

        // Recursive call
        return baseNum * CalculatePower(baseNum, exponent - 1);
    }
}

class Program5
{
    static void Main()
    {
        PowerCalculator pc = new PowerCalculator();

        Console.Write("Enter base: ");
        int baseNum = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter exponent: ");
        int exponent = Convert.ToInt32(Console.ReadLine());

        int result = pc.CalculatePower(baseNum, exponent);

        Console.WriteLine("Base = " + baseNum);
        Console.WriteLine("Exponent = " + exponent);
        Console.WriteLine("Result = " + result);
    }
}