using System;

class Employee
{
    // Properties
    public string Name { get; set; }
    public double BaseSalary { get; set; }

    // Virtual Method
    public virtual double CalculateSalary()
    {
        return BaseSalary;
    }
}

// Manager Class
class Manager : Employee
{
    public override double CalculateSalary()
    {
        return BaseSalary + (BaseSalary * 0.20); // 20% Bonus
    }
}

// Developer Class
class Developer : Employee
{
    public override double CalculateSalary()
    {
        return BaseSalary + (BaseSalary * 0.10); // 10% Bonus
    }
}

class Program2
{
    static void Main()
    {
        double baseSalary = 50000;

        // Runtime Polymorphism
        Employee manager = new Manager();
        manager.BaseSalary = baseSalary;

        Employee developer = new Developer();
        developer.BaseSalary = baseSalary;

        Console.WriteLine("Manager Salary = " + manager.CalculateSalary());
        Console.WriteLine("Developer Salary = " + developer.CalculateSalary());
    }
}