using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Program5
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();   // ✅ get list

            var result = products
                         .OrderBy(p => p.ProMrp)
                         .ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }

            Console.ReadLine();
            Console.ReadLine();
        }
    }
}
