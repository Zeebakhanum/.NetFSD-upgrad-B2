using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Program9
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();

            var result = products
                         .Where(p => p.ProCategory == "FMCG")
                         .OrderByDescending(p => p.ProMrp)
                         .FirstOrDefault();

            if (result != null)
            {
                Console.WriteLine($"{result.ProCode}\t{result.ProName}\t{result.ProMrp}");
            }

            Console.ReadLine();
        }
    }
}
