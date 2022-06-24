using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ssttek.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ssttek.ContactService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var optionsBuilder = new DbContextOptionsBuilder<SsttekContext>();
                    optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Ssttek;Persist Security Info=True;User ID=sa;Password=Password12*");//,
                    services.AddScoped<SsttekContext>(s => new SsttekContext(optionsBuilder.Options));

                    services.AddHostedService<Worker>();
                });
    }
}
