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

        public SsttekContext(DbContextOptions<SsttekContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            }
           
            optionsBuilder.UseSqlServer(connStr);  */
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
