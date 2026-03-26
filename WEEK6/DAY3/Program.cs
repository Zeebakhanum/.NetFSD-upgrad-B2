using Microsoft.Extensions.Configuration;
using System.IO;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json");

IConfiguration config = builder.Build();

ProductRepository repo = new ProductRepository(config);

while (true)
{
    Console.WriteLine("\n1. Add Product");
    Console.WriteLine("2. View Products");
    Console.WriteLine("3. Update Product");
    Console.WriteLine("4. Delete Product");
    Console.WriteLine("5. Exit");

    Console.Write("Enter choice: ");
    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Product p = new Product();

            Console.Write("Enter Name: ");
            p.ProductName = Console.ReadLine();

            Console.Write("Enter Category: ");
            p.Category = Console.ReadLine();

            Console.Write("Enter Price: ");
            p.Price = decimal.Parse(Console.ReadLine());

            repo.Insert(p);
            Console.WriteLine("✅ Product Added!");
            break;

        case 2:
            var list = repo.GetAll();

            foreach (var item in list)
            {
                Console.WriteLine($"{item.ProductId} | {item.ProductName} | {item.Category} | {item.Price}");
            }
            break;

        case 3:
            Product up = new Product();

            Console.Write("Enter ID: ");
            up.ProductId = int.Parse(Console.ReadLine());

            Console.Write("New Name: ");
            up.ProductName = Console.ReadLine();

            Console.Write("New Category: ");
            up.Category = Console.ReadLine();

            Console.Write("New Price: ");
            up.Price = decimal.Parse(Console.ReadLine());

            repo.Update(up);
            Console.WriteLine("✅ Updated!");
            break;

        case 4:
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());

            repo.Delete(id);
            Console.WriteLine("✅ Deleted!");
            break;

        case 5:
            return;

        default:
            Console.WriteLine("Invalid choice!");
            break;
    }
}