using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Infrastructure
{
    public static class Logger
    {
        static Serilog.Core.Logger logger;

        static Logger()
        {
            logger = new LoggerConfiguration()
                .WriteTo
                .File($"C:\\AdventureWorksApiLogs\\log.txt")
                .CreateLogger();
        }

        public static void Info(string message)
        {
            logger.Information(message);
        }

        public static void Error(string message, Exception ex = null)
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
