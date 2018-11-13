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
        private ProductsContext context;

        public ProductsRepository()
        {
            context = new ProductsContext();
        }

        public Product Get(int id)
        {
            Logger.Info($"Getting product with id = {id}...");
            return context.Products.Find(id);
        }

        public List<Product> GetAll()
        {
            Logger.Info("Getting all products...");
            return context.Products.ToList();
        }

        public void Create(Product product)
        {
            Logger.Info("Creating product...");
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Update(Product product)
        {
            Logger.Info("Updating product...");
            context.Products.Attach(product);
            context.SaveChanges();
        }

        public void Delete(Product product)
        {
            Logger.Info("Deleting product...");
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
