using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Program12
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();

            double maxPrice = products.Max(p => p.ProMrp);

            Console.WriteLine("Maximum Price: " + maxPrice);

            Console.ReadLine();
        }
    }
}
