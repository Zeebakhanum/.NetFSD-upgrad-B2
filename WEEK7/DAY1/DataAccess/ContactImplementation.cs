using AppDemo.Models;

namespace AppDemo.DataAccess
{
    public class ContactImplementation : IContactRepo<ContactInfo>
    {
        public static List<ContactInfo> contacts = new List<ContactInfo>
        {
             new ContactInfo{ ContactId=1,FirstName="Zeeba",LastName="R",CompanyName="Cognizant",EmailId="zee@gmail.com",MobileNo=123456789,Designation="Trainee Analyst" },
             new ContactInfo{ ContactId=2,FirstName="Shaaz",LastName="R",CompanyName="Cognizant",EmailId="shaaz@gmail.com",MobileNo=123456789,Designation="Trainee Analyst" },
             new ContactInfo{ ContactId=3,FirstName="Ruhi",LastName="T",CompanyName="wipro",EmailId="ruhi@gmail.com",MobileNo=123456789,Designation="Trainee Analyst" }
        };
        public bool AddContact(ContactInfo contact)
        {
            contacts.Add(contact);
            return true;
        }

        public ContactInfo GetContactById(int id)
        {
            var contact=contacts.FirstOrDefault(con => con.ContactId.Equals(id));
            return contact;
        }

        public List<ContactInfo> ShowContacts()
        {
            return contacts;
        }
    }
}
