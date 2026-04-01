using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace StudentApp.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        // ✅ GET → Show form + list
        [HttpGet("index")]
        public IActionResult Index()
        {
            var productList = GetProducts();
            ViewBag.Products = productList;

            return View();
        }

        // ✅ POST → Add product
        [HttpPost("add")]
        public IActionResult Add(string name, int price, int quantity)
        {
            var productList = GetProducts();

            // Add new product
            productList.Add(new Product
            {
                Name = name,
                Price = price,
                Quantity = quantity
            });

            // Save back to session
            HttpContext.Session.SetString("products",
                JsonSerializer.Serialize(productList));

            ViewBag.Products = productList;

            return View("Index");
        }

        // ✅ Helper method to get products from session
        private List<Product> GetProducts()
        {
            var data = HttpContext.Session.GetString("products");

            if (string.IsNullOrEmpty(data))
                return new List<Product>();

            return JsonSerializer.Deserialize<List<Product>>(data);
        }
    }

    // Simple class (NOT model binding, just structure)
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}