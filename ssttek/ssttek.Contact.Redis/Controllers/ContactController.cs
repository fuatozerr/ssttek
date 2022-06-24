using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ssttek.Infrastructure.Abstract;
using ssttrek.Business.Abstract;
using ssttrek.Entities;
using System.Threading.Tasks;

namespace ssttek.Contact.Redis.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] ContactModel contact)
        {
            var contacts = await contactService.CreateContact(contact);
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact([FromBody] ContactModel contact)
        {
            var contacts = await contactService.UpdateContact(contact);
            return Ok(contacts);
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteContact(int contactId)
        {
            contactService.DeleteContact(contactId);
            return Ok();
        }
    }
}
