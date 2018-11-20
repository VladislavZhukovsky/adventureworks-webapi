using AdventureWorks.DbModel;
using AdventureWorks.Infrastructure;
using AdventureWorks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdventureWorks.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly Logger logger;
        private readonly AzureStorageClient.AzureStorageClient azureStorageClient;
        private readonly ProductsService productsService;

        public ProductsController()
        {
            azureStorageClient = new AzureStorageClient.AzureStorageClient();
            logger = new Logger(azureStorageClient);
            productsService = new ProductsService(azureStorageClient, logger);
        }

        public IHttpActionResult GetProduct(int id)
        {
            try
            {
                var result = productsService.GetProduct(id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    logger.Info($"Product with id = {id} not found");
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return BadRequest();
            }
        }

        public IHttpActionResult GetAllProducts()
        {
            try
            {
                return Ok(productsService.GetAllProducts());
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message, ex);
                return BadRequest();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (productsService != null)
                {
                    productsService.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
