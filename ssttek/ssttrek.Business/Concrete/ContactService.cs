using ssttek.Infrastructure.Abstract;
using ssttrek.Business.Abstract;
using ssttrek.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssttrek.Business.Concrete
{
    public class ContactService : IContactService
    {
        private IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public Task<Contact> CreateContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void DeleteContact(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            var result = await _contactRepository.GetAll();
            return result;
        }

        public Task<Contact> GetContact(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
