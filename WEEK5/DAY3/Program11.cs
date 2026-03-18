using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Program11
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();

            int count = products
                        .Where(p => p.ProCategory == "FMCG")
                        .Count();

            Console.WriteLine("Total FMCG Products: " + count);

            Console.ReadLine();
        }
    }
}
