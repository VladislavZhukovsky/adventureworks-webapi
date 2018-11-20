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
            logger.Info($"ProductsRepository: getting product with id = {id}...");
            return context.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            logger.Info("ProductsRepository: getting all products...");
            return context.Products.AsEnumerable();
        }

        public void Create(Product product)
        {
            logger.Info("ProductsRepository: creating product...");
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Update(Product product)
        {
            logger.Info("ProductsRepository: updating product...");
            context.Products.Attach(product);
            context.SaveChanges();
        }

        public void Delete(Product product)
        {
            logger.Info("ProductsRepository: deleting product...");
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
