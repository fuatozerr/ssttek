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

        public async Task<int> CreateContact(ContactModel contact)
        {
            var result = await _contactRepository.AddAsync(contact);
            return result;
            
        }

        public void DeleteContact(int id)
        {
            _contactRepository.Delete(id);
        }

        public async Task<List<ContactModel>> GetAllContacts()
        {
            var result = await _contactRepository.GetAll();
            return result;
        }

        public async Task<ContactModel> GetContact(int id)
        {
            var result = await _contactRepository.GetByIdAsync(id);
            return result;
        }

        public async Task<int> UpdateContact(ContactModel contact)
        {
            var result = await _contactRepository.UpdateAsync(contact);

            return result;

        }
    }
}
