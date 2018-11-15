using AdventureWorks.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.DbModel
{
    public class ProductsRepository: IDisposable
    {
        private readonly Logger logger;
        private ProductsContext context;

        public ProductsRepository(Logger logger)
        {
            context = new ProductsContext();
            this.logger = logger;
        }

        public Product Get(int id)
        {
            logger.Info($"Getting product with id = {id}...");
            return context.Products.Find(id);
        }

        public List<Product> GetAll()
        {
            logger.Info("Getting all products...");
            return context.Products.ToList();
        }

        public void Create(Product product)
        {
            logger.Info("Creating product...");
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Update(Product product)
        {
            logger.Info("Updating product...");
            context.Products.Attach(product);
            context.SaveChanges();
        }

        public void Delete(Product product)
        {
            logger.Info("Deleting product...");
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}
