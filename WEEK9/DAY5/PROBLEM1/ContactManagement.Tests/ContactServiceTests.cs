using NUnit.Framework;
using ContactManagement.Services;
using ContactManagement.Interfaces;
using ContactManagement.Models;

namespace ContactManagement.Tests
{
    public class ContactServiceTests
    {
        private IContactService _service;

        [SetUp]
        public void Setup()
        {
            _service = new ContactService();
        }

        // ✅ Add Contact Test
        [Test]
        public void AddContact_ShouldAddContactSuccessfully()
        {
            // Arrange
            var contact = new Contact
            {
                Id = 1,
                Name = "John",
                Email = "john@test.com"
            };

            // Act
            _service.AddContact(contact);
            var result = _service.GetAllContacts();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        // ✅ Get All Contacts Test
        [Test]
        public void GetAllContacts_ShouldReturnContacts()
        {
            // Arrange
            _service.AddContact(new Contact { Id = 1, Name = "A", Email = "a@test.com" });

            // Act
            var result = _service.GetAllContacts();

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        // ✅ Get Contact By Id
        [Test]
        public void GetContactById_ShouldReturnCorrectContact()
        {
            // Arrange
            _service.AddContact(new Contact { Id = 1, Name = "John", Email = "john@test.com" });

            // Act
            var result = _service.GetContactById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("John", result.Name);
        }

        // ✅ Delete Contact Test
        [Test]
        public void DeleteContact_ShouldDeleteSuccessfully()
        {
            // Arrange
            _service.AddContact(new Contact { Id = 1, Name = "John", Email = "john@test.com" });

            // Act
            var deleted = _service.DeleteContact(1);
            var result = _service.GetAllContacts();

            // Assert
            Assert.IsTrue(deleted);
            Assert.AreEqual(0, result.Count);
        }
    }
}