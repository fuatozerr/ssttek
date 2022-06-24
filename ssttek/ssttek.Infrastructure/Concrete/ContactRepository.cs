using Microsoft.EntityFrameworkCore;
using ssttek.DataAccess;
using ssttek.Infrastructure.Abstract;
using ssttrek.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssttek.Infrastructure.Concrete
{
    public class ContactRepository : GenericRepository<ContactModel>, IContactRepository
    {
        public ContactRepository(SsttekContext dbContext) : base(dbContext)
        {
        }
    }
}
