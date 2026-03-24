using System;

class Program2
{
    static void Main(string[] args)
    {
        Console.Write("Enter Product Name: ");
        string productName = Console.ReadLine();

        Console.Write("Enter Product Price: ");
        double price = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Discount Percentage: ");
        double discount = Convert.ToDouble(Console.ReadLine());

        //  Place Breakpoint Here
        double finalPrice = price - (price * discount / 100);

        Console.WriteLine("\n--- Bill Details ---");
        Console.WriteLine($"Product: {productName}");
        Console.WriteLine($"Original Price: {price}");
        Console.WriteLine($"Discount: {discount}%");
        Console.WriteLine($"Final Price: {finalPrice}");
    }
}