using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ContactApp.Models;
using System.Collections.Generic;

namespace ContactApp.Interfaces
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        List<Contact> GetContacts();
        bool RemoveContact(int id);
    }
}