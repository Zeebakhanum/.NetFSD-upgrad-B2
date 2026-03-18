using System;

class Product
{
    // Private fields
    private string name;
    private double price;

    // Property for Name
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // Property for Price with validation
    public double Price
    {
        get { return price; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Price cannot be negative.");
            }
            else
            {
                price = value;
            }
        }
    }

    // Virtual method
    public virtual double CalculateDiscount()
    {
        return price;
    }
}

// Electronics class
class Electronics : Product
{
    public override double CalculateDiscount()
    {
        return Price - (Price * 0.05); // 5% discount
    }
}

// Clothing class
class Clothing : Product
{
    public override double CalculateDiscount()
    {
        return Price - (Price * 0.15); // 15% discount
    }
}

class Program3
{
    static void Main()
    {
        // Electronics Product
        Product electronicItem = new Electronics();
        electronicItem.Name = "Laptop";
        electronicItem.Price = 20000;

        double finalPrice = electronicItem.CalculateDiscount();

        Console.WriteLine("Final Price after 5% discount = " + finalPrice);
    }
}