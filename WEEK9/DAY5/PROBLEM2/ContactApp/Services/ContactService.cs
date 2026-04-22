using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Interfaces;
using ContactApp.Models;


namespace ContactApp.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public void AddContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            _repository.Add(contact);
        }

        public List<Contact> GetContacts()
        {
            return _repository.GetAll();
        }

        public bool RemoveContact(int id)
        {
            return _repository.Delete(id);
        }
    }
}