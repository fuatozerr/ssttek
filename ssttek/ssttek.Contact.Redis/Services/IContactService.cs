using ssttek.Shared.Dto;
using System.Threading.Tasks;

namespace ssttek.Contact.Redis.Services
{
    public interface IContactService
    {
        Task<Response<ssttrek.Entities.Contact>> GetContactById(string userId);
    }
}
