using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace AdventureWorks.AzureStorageClient.Clients
{
    public class MessageQueueClient
    {
        private readonly CloudQueueClient queueClient;

        public MessageQueueClient(CloudStorageAccount storageAccount)
        {
            queueClient = storageAccount.CreateCloudQueueClient();
        }

        public void WriteMessage(string queueName, string message)
        {
            var queue = queueClient.GetQueueReference(queueName);
            queue.AddMessage(new CloudQueueMessage(message));
        }
    }
}
