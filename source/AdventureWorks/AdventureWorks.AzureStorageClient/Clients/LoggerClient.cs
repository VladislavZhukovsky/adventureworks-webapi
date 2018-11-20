using Microsoft.WindowsAzure.Storage;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.AzureStorageClient.Clients
{
    public class LoggerClient
    {
        private readonly Serilog.Core.Logger logger;

        public LoggerClient(CloudStorageAccount storageAccount)
        {
            logger = new LoggerConfiguration()
                .WriteTo
                .AzureTableStorageWithProperties(storageAccount, storageTableName: ConfigurationManager.AppSettings["StorageTableName"])
                .CreateLogger();
        }

        public void Info(string message)
        {
            logger.Information(message);
        }

        public void Error(string message, Exception ex = null)
        {
            if (ex == null)
            {
                logger.Error(message);
            }
            else
            {
                logger.Error(ex, message);
            }
        }
    }
}
