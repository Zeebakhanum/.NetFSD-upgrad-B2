using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Program15
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();

            bool anyBelow30 = products.Any(p => p.ProMrp < 30);

            Console.WriteLine("Is any product below Rs.30? " + anyBelow30);
            Console.ReadLine();
        }
    }
}
