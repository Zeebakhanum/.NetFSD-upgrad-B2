using System;

class OrderCalculator
{
    // Method with optional parameters
    public void CalculateFinalAmount(int price, int quantity, double discount = 0, double shipping = 50)
    {
        double subtotal = price * quantity;
        double discountAmount = subtotal * discount / 100;
        double amountAfterDiscount = subtotal - discountAmount;
        double finalAmount = amountAfterDiscount + shipping;

        Console.WriteLine("Subtotal = " + subtotal);
        Console.WriteLine("Discount Applied = " + discountAmount);
        Console.WriteLine("Shipping Charge = " + shipping);
        Console.WriteLine("Final Amount = " + finalAmount);
    }
}

class Program4
{
    static void Main()
    {
        OrderCalculator oc = new OrderCalculator();

        Console.WriteLine("Order 1 (No discount, default shipping)");
        oc.CalculateFinalAmount(100, 2);

        Console.WriteLine("\nOrder 2 (With discount)");
        oc.CalculateFinalAmount(100, 2, 10);

        Console.WriteLine("\nOrder 3 (With discount and custom shipping)");
        oc.CalculateFinalAmount(100, 2, 10, 30);
    }
}