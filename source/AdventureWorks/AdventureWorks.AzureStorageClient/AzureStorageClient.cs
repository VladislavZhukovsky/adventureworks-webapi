using AdventureWorks.AzureStorageClient.Clients;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.AzureStorageClient
{
    public class AzureStorageClient
    {
        private readonly CloudStorageAccount storageAccount;

        public AzureStorageClient()
        {
            storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
            LoggerClient = new LoggerClient(storageAccount);
            BlobClient = new BlobClient(storageAccount);
            MessageQueueClient = new MessageQueueClient(storageAccount);
        }

        public LoggerClient LoggerClient { get; private set; }
        public BlobClient BlobClient { get; private set; }
        public MessageQueueClient MessageQueueClient { get; private set; }
    }
}
