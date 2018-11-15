using Microsoft.WindowsAzure.Storage;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Infrastructure
{
    public class Logger
    {
        private readonly Serilog.Core.Logger logger;

        public Logger()
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);

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
