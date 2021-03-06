using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ssttek.Infrastructure.Queue
{
    public static class QueueFactory
    {
        //rabbitMQ
        public static void SendMessageToExchange(string exchangeName, string exchangeType, string queueName, object obj)
        {

            var channel = CreateBasicConsumer()
                            .EnsureExchange(exchangeName, exchangeType)
                            .EnsureQueue(queueName, exchangeName).Model;
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(obj));
            channel.BasicPublish(exchangeName, queueName, null, body);
        }
        public static EventingBasicConsumer CreateBasicConsumer()
        {
            var factory = new ConnectionFactory() { HostName = SsttekQueueConstants.RabbitMQHost };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var result = new EventingBasicConsumer(channel);
            return result;
        }

        /// <summary>
        /// building pattern
        /// </summary>
        /// <param name="consumer"></param>
        /// <param name="exchangeName"></param>
        /// <param name="exchangeType"></param>
        /// <returns></returns>
        public static EventingBasicConsumer EnsureExchange(this EventingBasicConsumer consumer, string exchangeName, string exchangeType = SsttekQueueConstants.DefaultExchangeType)
        {
            consumer.Model.ExchangeDeclare(exchangeName, exchangeType, durable: false, autoDelete: false);

            return consumer;
        }

        public static EventingBasicConsumer EnsureQueue(this EventingBasicConsumer consumer, string queueName, string exchangeName)
        {
            consumer.Model.QueueDeclare(queueName, durable: false, exclusive: false, autoDelete: false, null);
            consumer.Model.QueueBind(queueName, exchangeName, queueName); //direct type exchange


            return consumer;
        }
    }
}
