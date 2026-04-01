using Microsoft.AspNetCore.Mvc;

namespace StudentApp.Controllers
{
    [Route("calculator")]
    public class CalculatorController : Controller
    {
        // ✅ GET → Show form
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        // ✅ POST → Handle calculation
        [HttpPost("add")]
        public IActionResult Add(int num1, int num2)
        {
            int result = num1 + num2;

            // Pass result using ViewData
            ViewData["Result"] = result;

            return View("Result");
        }
    }
}