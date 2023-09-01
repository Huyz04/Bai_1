using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Diagnostics;
using Bai1.WebAPI.Models;
using Bai1.WebAPI.Provider;
using System.CodeDom;

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
                var m  = new mainn();
                return m.GetProducts();
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
                var m = new mainn();
                return m.GetProducts(product_id);
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
                var m = new mainn();
                return m.InsertProducts(prd);
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
                var m = new mainn();
                return m.UpdateProducts(product_id, prd);
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
                var m = new mainn();
                return m.DeleteProducts(product_id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
