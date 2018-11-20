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
        private LoggerClient loggerClient;
        private BlobClient blobClient;
        private MessageQueueClient messageQueueClient;

        public AzureStorageClient()
        {
            storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
            loggerClient = new LoggerClient(storageAccount);
            blobClient = new BlobClient(storageAccount);
            messageQueueClient = new MessageQueueClient(storageAccount);
        }

        public void InitializeLoggerClient()
        {
        }

        public void InitializeBlobClient()
        {
        }

        public void InitializeMessageQueueClient()
        {
        }
    }
}
