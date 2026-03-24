using System;

// 🔹 1. Interface (Strategy)
interface IDiscountStrategy
{
    double CalculateDiscount(double amount);
}

// 🔹 2. Concrete Strategies

class RegularCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount)
    {
        return amount * 0.05; // 5% discount
    }
}

class PremiumCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount)
    {
        return amount * 0.10; // 10% discount
    }
}

class VipCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount)
    {
        return amount * 0.20; // 20% discount
    }
}

// 🔹 3. Price Calculator (Uses Strategy)
class PriceCalculator
{
    private IDiscountStrategy discountStrategy;

    public PriceCalculator(IDiscountStrategy strategy)
    {
        discountStrategy = strategy;
    }

    public double CalculateFinalPrice(double amount)
    {
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative.");

        double discount = discountStrategy.CalculateDiscount(amount);
        return amount - discount;
    }
}

// 🔹 Main Program
class Program2
{
    static void Main(string[] args)
    {
        double amount = 1000;

        // Choose discount type dynamically
        IDiscountStrategy strategy = new PremiumCustomerDiscount();

        PriceCalculator calculator = new PriceCalculator(strategy);

        double finalPrice = calculator.CalculateFinalPrice(amount);

        Console.WriteLine($"Original Price: {amount}");
        Console.WriteLine($"Final Price after discount: {finalPrice}");
    }
}