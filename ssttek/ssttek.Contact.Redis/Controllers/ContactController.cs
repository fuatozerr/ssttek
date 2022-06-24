using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using ssttek.Infrastructure.Abstract;
using ssttrek.Business.Abstract;
using ssttrek.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ssttek.Contact.Redis.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;
        private readonly IDistributedCache distributedCache;


        public ContactController(IContactService contactService, IDistributedCache distributedCache)
        {
            this.contactService = contactService;
            this.distributedCache = distributedCache;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContact()
        {
            var contacts = await contactService.GetAllContacts();

            return Ok(contacts);
        }

        [HttpGet]
        public async Task<IActionResult> GetContactById(int id)
        {
            var cacheKey = id;
            ContactModel contact;

            string json;
            var citiesFromCache = await distributedCache.GetAsync(id.ToString());
            if (citiesFromCache != null)
            {
                json = Encoding.UTF8.GetString(citiesFromCache);
                contact = JsonConvert.DeserializeObject<ContactModel>(json);
            }
            else
            {
                contact = await Task.Run(() => contactService.GetContact(id));
                json = JsonConvert.SerializeObject(contact);
                citiesFromCache = Encoding.UTF8.GetBytes(json);
                var options = new DistributedCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromDays(1)) // belirli bir süre erişilmemiş ise expire eder
                        .SetAbsoluteExpiration(DateTime.Now.AddMonths(1)); // belirli bir süre sonra expire eder.
                await distributedCache.SetAsync(cacheKey.ToString(), citiesFromCache, options);

            }
            return Ok(contact);
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
