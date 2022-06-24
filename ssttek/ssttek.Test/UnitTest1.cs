using Microsoft.Extensions.Caching.Distributed;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ssttek.Contact.Redis.Controllers;
using ssttrek.Business.Abstract;

namespace ssttek.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void TestMethod1()
        {
            var repository = new Mock<IContactService>();
            var distributedCache = new Mock<IDistributedCache>();
            repository.Setup(repo => repo.GetAllContacts());
            var controller = new ContactController(repository.Object, distributedCache.Object);

            var result = await controller.GetAllContact();
            Assert.IsNotNull(result);

        }
    }
}
