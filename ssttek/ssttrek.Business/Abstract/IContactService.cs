using ssttrek.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssttrek.Business.Abstract
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllContacts();
        Task<Contact> GetContact(int id);
        Task<Contact> CreateContact(Contact contact);
        Task<Contact> UpdateContact(Contact contact); 
        void DeleteContact(int id);
    }
}
