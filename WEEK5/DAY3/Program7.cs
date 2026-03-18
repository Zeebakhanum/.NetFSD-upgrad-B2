using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Program7
    {
        static void Main()
        {
            
            Product product = new Product();
            var products = product.GetProducts();

            var result = products
                         .GroupBy(p => p.ProCategory);

            foreach (var group in result)
            {
                Console.WriteLine($"\nCategory: {group.Key}");

                foreach (var item in group)
                {
                    Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
                }
            }
            Console.ReadLine();
        }
    }
}
