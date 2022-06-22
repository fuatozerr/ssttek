using System.Threading.Tasks;

namespace ssttek.Contact.Redis.Services
{
    public interface IContactService
    {
        Task<Contact> GetContact(int id);
    }
}
