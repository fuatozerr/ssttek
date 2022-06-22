using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ssttek.Infrastructure.Abstract;
using ssttrek.Business.Abstract;
using System.Threading.Tasks;

namespace ssttek.Contact.Redis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContact()
        {
            var contacts = await contactService.GetAllContacts();

            return Ok(contacts);
        }
    }
}
