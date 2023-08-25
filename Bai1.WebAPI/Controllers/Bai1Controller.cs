using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Diagnostics;
using Bai1_BL;
using Bai1_Entity;

namespace Bai1.WebAPI.Controllers
{
    [RoutePrefix("products")]
    public class Bai1Controller : ApiController
    {
        // GET: api/Bai1
        [Route("all")]
        public IEnumerable<Product> Get()
        {
            try
            {
                var productBL = new ProductBL();
                return productBL.GetProducts();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        // GET: api/Bai1/5
        [Route("{product_id}")]
        public object Get(int  product_id)
        {
            try
            {
                var productBL = new ProductBL();
                return productBL.GetProducts(product_id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: api/Bai1 
        [Route("")]
        public int Post([FromBody]Product prd)
        {
            try
            {
                var productBL = new ProductBL();
                return productBL.UpdateProducts(prd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT: api/Bai1/5
        [Route("{product_id}")]
        public int Put(int product_id, [FromBody]Product prd)
        {
            try
            {
                var productBL = new ProductBL();
                return productBL.UpdateProducts(product_id, prd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE: api/Bai1/5
        [Route("{product_id}")]
        public int Delete(int product_id)
        {
            try
            {
                var productBL = new ProductBL();
                return productBL.DeleteProducts(product_id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
