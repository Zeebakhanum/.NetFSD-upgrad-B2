using Microsoft.AspNetCore.Mvc;

namespace StudentApp.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        // ✅ GET → Show form
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        // ✅ POST → Handle form
        [HttpPost("register")]
        public IActionResult Register(string studentName, int age, string course)
        {
            TempData["Name"] = studentName;
            TempData["Age"] = age;
            TempData["Course"] = course;

            return RedirectToAction("Display");
        }

        // ✅ 👉 PASTE YOUR CODE HERE
        [HttpGet("display")]
        public IActionResult Display()
        {
            ViewBag.Name = TempData["Name"];
            ViewBag.Age = TempData["Age"];
            ViewBag.Course = TempData["Course"];

            return View();
        }
    }
}