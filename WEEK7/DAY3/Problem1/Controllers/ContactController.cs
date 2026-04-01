using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;
using StudentApp.Services;

namespace StudentApp.Controllers
{
    [Route("contact")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        // ✅ Constructor Injection
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // ✅ Show all contacts
        [HttpGet("show")]
        public IActionResult ShowContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return View(contacts);
        }

        // ✅ Get by ID
        [HttpGet("get/{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.GetContactById(id);
            return View(contact);
        }

        // ✅ GET → Add form
        [HttpGet("add")]
        public IActionResult AddContact()
        {
            return View();
        }

        // ✅ POST → Add contact
        [HttpPost("add")]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            _contactService.AddContact(contactInfo);
            return RedirectToAction("ShowContacts");
        }
    }
}