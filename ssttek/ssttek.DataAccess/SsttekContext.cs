using Microsoft.EntityFrameworkCore;
using ssttrek.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssttek.DataAccess
{
    public class SsttekContext: DbContext
    {
        public const string DEFAULT_SCHEMA = "dbo";
        public const string connStr = "Data Source=localhost;Initial Catalog=Ssttek;Persist Security Info=True;User ID=sa;Password=Password12*"; //appsettingstende okuyabilirim.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connStr);  
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
