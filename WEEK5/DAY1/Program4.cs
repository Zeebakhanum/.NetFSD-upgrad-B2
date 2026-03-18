using System;

class Vehicle
{
    // Private fields
    private string brand;
    private double rentalRatePerDay;

    // Property for Brand
    public string Brand
    {
        get { return brand; }
        set { brand = value; }
    }

    // Property for RentalRatePerDay with validation
    public double RentalRatePerDay
    {
        get { return rentalRatePerDay; }
        set
        {
            if (value < 0)
                Console.WriteLine("Rental rate cannot be negative.");
            else
                rentalRatePerDay = value;
        }
    }

    // Virtual method
    public virtual double CalculateRental(int days)
    {
        return rentalRatePerDay * days;
    }
}

// Car class
class Car : Vehicle
{
    public override double CalculateRental(int days)
    {
        if (days <= 0)
        {
            Console.WriteLine("Invalid rental days.");
            return 0;
        }

        double total = RentalRatePerDay * days;
        total += 500; // Insurance charge
        return total;
    }
}

// Bike class
class Bike : Vehicle
{
    public override double CalculateRental(int days)
    {
        if (days <= 0)
        {
            Console.WriteLine("Invalid rental days.");
            return 0;
        }

        double total = RentalRatePerDay * days;
        total -= total * 0.05; // 5% discount
        return total;
    }
}

class Program4
{
    static void Main()
    {
        Vehicle car = new Car();
        car.Brand = "Toyota";
        car.RentalRatePerDay = 2000;

        int days = 3;

        double totalRental = car.CalculateRental(days);

        Console.WriteLine("Total Rental = " + totalRental);
    }
}