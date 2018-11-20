using AdventureWorks.AzureStorageClient.Clients;
using AdventureWorks.DbModel;
using AdventureWorks.Infrastructure;
using AdventureWorks.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Services
{
    public class ProductsService: IDisposable
    {
        private readonly Logger logger;
        private readonly ProductsRepository repository;
        private readonly AzureStorageClient.AzureStorageClient azureStorageClient;

        private readonly string blobContainerName = ConfigurationManager.AppSettings["StorageBlobContainerName"];
        private readonly string messageQueueName = ConfigurationManager.AppSettings["StorageMessageQueueName"];

        public ProductsService(AzureStorageClient.AzureStorageClient azureStorageClient, Logger logger)
        {
            this.logger = logger;
            repository = new ProductsRepository(logger);
            this.azureStorageClient = azureStorageClient;
        }

        public Product GetProduct(int id)
        {
            var result = repository.Get(id);
            return result;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var result = repository.GetAll().ToList();
            return result;
        }

        public Guid UploadDocument(Document document)
        {
            var bytes = Convert.FromBase64String(document.Base64Content);
            var fileId = azureStorageClient.BlobClient.UploadFile(blobContainerName, document.Filename, bytes);
            azureStorageClient.MessageQueueClient.WriteMessage(messageQueueName, $"Document {document.Filename} added to blob with id = {fileId}");
            return fileId;
        }

        public void Dispose()
        {
            if (repository != null)
            {
                repository.Dispose();
            }
        }
    }
}
