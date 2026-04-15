using Microsoft.AspNetCore.Mvc;
using ContactAPI.Repositories;
using ContactAPI.Models;
using ContactAPI.Exceptions;

namespace ContactAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ContactRepository _repo;
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(ILogger<ContactsController> logger)
        {
            _repo = new ContactRepository();
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Fetching all contacts");
            return Ok(_repo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contact = _repo.GetById(id);
            if (contact == null)
                throw new NotFoundException("Contact not found");

            return Ok(contact);
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            _repo.Add(contact);
            _logger.LogInformation("Contact created");
            return Ok(contact);
        }

        [HttpPut]
        public IActionResult Update(Contact contact)
        {
            _repo.Update(contact);
            _logger.LogInformation("Contact updated");
            return Ok(contact);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            _logger.LogInformation("Contact deleted");
            return Ok();
        }
    }
}
