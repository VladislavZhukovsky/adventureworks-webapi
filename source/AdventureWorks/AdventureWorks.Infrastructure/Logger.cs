using AdventureWorks.AzureStorageClient.Clients;
using System;

namespace AdventureWorks.Infrastructure
{
    public class Logger
    {
        private readonly LoggerClient logger;

        public Logger(LoggerClient loggerCLient)
        {
            this.logger = loggerCLient;
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Error(string message, Exception ex = null)
        {
            if (ex == null)
            {
                logger.Error(message);
            }
            else
            {
                logger.Error(message, ex);
            }
        }
    }
}
