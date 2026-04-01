using Microsoft.AspNetCore.Mvc;

namespace StudentApp.Controllers
{
    [Route("feedback")]
    public class FeedbackController : Controller
    {
        // ✅ GET → Show form
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        // ✅ POST → Handle form
        [HttpPost("submit")]
        public IActionResult Submit(string name, string comments, int rating)
        {
            string message;

            // ✅ Conditional Logic
            if (rating >= 4)
            {
                message = "Thank You for your positive feedback!";
            }
            else
            {
                message = "We will improve based on your feedback.";
            }

            // ✅ Pass message using ViewData
            ViewData["Message"] = message;

            return View("Index");
        }
    }
}