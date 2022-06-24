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
        Task<List<ContactModel>> GetAllContacts();
        Task<ContactModel> GetContact(int id);
        Task<int> CreateContact(ContactModel contact);
        Task<int> UpdateContact(ContactModel contact);
        void DeleteContact(int id);
    }
}
