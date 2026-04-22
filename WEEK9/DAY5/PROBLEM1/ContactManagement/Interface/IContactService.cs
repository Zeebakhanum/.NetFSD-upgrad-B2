using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ContactManagement.Models;
using System.Collections.Generic;

namespace ContactManagement.Interfaces
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
        bool DeleteContact(int id);
    }
}