using AdventureWorks.DbModel;
using AdventureWorks.Infrastructure;
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
        private readonly ProductsRepository repository;

        public ProductsController()
        {
            logger = new Logger();
            repository = new ProductsRepository(logger);
        }

        public IHttpActionResult GetProduct(int id)
        {
            try
            {
                var result = repository.Get(id);
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
                return Ok(repository.GetAll());
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
                if (repository != null)
                {
                    repository.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
