using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ssttek.DataAccess;
using ssttrek.Entities;

namespace ssttek.ContactService
{
    public class IdEntity
    {
        public int Id { get; set; }

    }
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly SsttekContext ssttekContext;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName="guest",Password="guest"};

            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<SsttekContext>();

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "ContactDeletingQueue",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.Span;
                        var bodycount = ea.Body.Length;
                        var message = Encoding.UTF8.GetString(body);
                        ContactModel messageJson = JsonConvert.DeserializeObject<ContactModel>(message);
                        dbContext.Remove(messageJson);
                        dbContext.SaveChanges();
                        Console.WriteLine(" Received {0}", message);
                    };
                    channel.BasicConsume(queue: "ContactDeletingQueue",
                                         autoAck: true,
                                         consumer: consumer);
                }
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
