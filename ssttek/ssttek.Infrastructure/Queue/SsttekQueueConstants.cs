using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssttek.Infrastructure.Queue
{
    public class SsttekQueueConstants
    {
        public const string RabbitMQHost = "localhost";
        public const string DefaultExchangeType = "direct";

        public const string ContactAddingName = "ContactAdding";
        public const string ContactAddingQueueName = "ContactAddingQueue";

        public const string ContactDeletingName = "ContactDeleting";
        public const string ContactDeletingQueueName = "ContactDeletingQueue";


    }
}
