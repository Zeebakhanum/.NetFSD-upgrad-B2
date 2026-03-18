using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Program13
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();

            double minPrice = products.Min(p => p.ProMrp);

            Console.WriteLine("Minimum Price: " + minPrice);
            Console.ReadLine();
        }
    }
}
