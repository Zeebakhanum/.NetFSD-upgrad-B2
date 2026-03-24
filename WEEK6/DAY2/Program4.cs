using System;

// 🔹 1. Small Interfaces

interface IPrinter
{
    void Print();
}

interface IScanner
{
    void Scan();
}

interface IFax
{
    void Fax();
}

// 🔹 2. Basic Printer (Only Print)

class BasicPrinter : IPrinter
{
    public void Print()
    {
        Console.WriteLine("Basic Printer: Printing document...");
    }
}

// 🔹 3. Advanced Printer (Print + Scan + Fax)

class AdvancedPrinter : IPrinter, IScanner, IFax
{
    public void Print()
    {
        Console.WriteLine("Advanced Printer: Printing document...");
    }

    public void Scan()
    {
        Console.WriteLine("Advanced Printer: Scanning document...");
    }

    public void Fax()
    {
        Console.WriteLine("Advanced Printer: Sending fax...");
    }
}

// 🔹 Main Program
class Program4
{
    static void Main(string[] args)
    {
        // Basic Printer
        IPrinter basic = new BasicPrinter();
        basic.Print();

        Console.WriteLine();

        // Advanced Printer
        AdvancedPrinter advanced = new AdvancedPrinter();
        advanced.Print();
        advanced.Scan();
        advanced.Fax();
    }
}