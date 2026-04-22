using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ContactApp.Models;
using System.Collections.Generic;

namespace ContactApp.Interfaces
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        List<Contact> GetAll();
        bool Delete(int id);
    }
}