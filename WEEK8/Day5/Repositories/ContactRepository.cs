using ContactAPI.Models;

namespace ContactAPI.Repositories
{
    public class ContactRepository
    {
        private static List<Contact> contacts = new List<Contact>
        {
            new Contact{ ContactId=1, Name="John", Email="john@test.com", Phone="1111111111"},
            new Contact{ ContactId=2, Name="Sara", Email="sara@test.com", Phone="2222222222"}
        };

        public List<Contact> GetAll() => contacts;

        public Contact GetById(int id)
        {
            return contacts.FirstOrDefault(x => x.ContactId == id);
        }

        public void Add(Contact contact)
        {
            contacts.Add(contact);
        }

        public void Update(Contact contact)
        {
            var existing = contacts.FirstOrDefault(x => x.ContactId == contact.ContactId);
            if (existing != null)
            {
                existing.Name = contact.Name;
                existing.Email = contact.Email;
                existing.Phone = contact.Phone;
            }
        }

        public void Delete(int id)
        {
            var contact = contacts.FirstOrDefault(x => x.ContactId == id);
            if (contact != null)
                contacts.Remove(contact);
        }
    }
}
