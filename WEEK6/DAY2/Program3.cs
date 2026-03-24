using System;

// 🔹 1. Base Class
abstract class Shape
{
    public abstract double CalculateArea();
}

// 🔹 2. Rectangle Class
class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

// 🔹 3. Circle Class
class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

// 🔹 4. Area Calculator (Uses Base Class)
class AreaCalculator
{
    public void PrintArea(Shape shape)
    {
        double area = shape.CalculateArea();
        Console.WriteLine($"Area: {area}");
    }
}

// 🔹 Main Program
class Program3
{
    static void Main(string[] args)
    {
        AreaCalculator calculator = new AreaCalculator();

        // Rectangle
        Shape rect = new Rectangle(5, 4);
        calculator.PrintArea(rect);

        // Circle
        Shape circle = new Circle(3);
        calculator.PrintArea(circle);
    }
}