using AdventureWorks.DbModel;
using AdventureWorks.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Services
{
    public class ProductsService: IDisposable
    {
        private readonly Logger logger;
        private readonly ProductsRepository repository;

        public ProductsService(AzureStorageClient.AzureStorageClient azureStorageClient, Logger logger)
        {
            this.logger = logger;
            repository = new ProductsRepository(logger);
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

        public void Dispose()
        {
            if (repository != null)
            {
                repository.Dispose();
            }
        }
    }
}
