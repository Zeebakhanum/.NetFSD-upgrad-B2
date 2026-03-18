using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Program10
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();

            int count = products.Count();

            Console.WriteLine("Total Products: " + count);

            Console.ReadLine();
        }
    }
}
