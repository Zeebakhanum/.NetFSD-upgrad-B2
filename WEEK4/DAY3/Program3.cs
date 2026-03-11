using System;

class Program3
{
    static void Main(string[] args)
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter Salary: ");
        double salary = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Experience (years): ");
        int experience = Convert.ToInt32(Console.ReadLine());

        double bonusRate;

        // Using if-else to determine bonus rate
        if (experience < 2)
            bonusRate = 0.05;
        else if (experience <= 5)
            bonusRate = 0.10;
        else
            bonusRate = 0.15;

        // Using ternary operator to ensure salary is valid
        double bonus = salary > 0 ? salary * bonusRate : 0;

        double finalSalary = salary + bonus;

        Console.WriteLine("\nEmployee: " + name);
        Console.WriteLine("Bonus: " + bonus.ToString("F2"));
        Console.WriteLine("Final Salary: " + finalSalary.ToString("F2"));
    }
}