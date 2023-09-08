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
using Microsoft.EntityFrameworkCore;
using System.Web.Configuration;

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
        // GET total
        [Route("total")]
        public int GetTotal()
        {
            try
            {
                var m = new mainn();
                return m.GetTotal();
            }
            catch (Exception)
            {
                throw;
            }
        }
        // GET: api/Bai1/Name/Namee
        [Route("{product_info}/{product_type}")]
        public IEnumerable<Product> GetFind(string product_info, string product_type)
        {
            try
            {
                var m = new mainn();
                return m.FindProducts(product_info, product_type) ;
            }
            catch (Exception)
            {
                throw;
            }
        }
        // GET : phan trang
        [Route("Page/{ignore}/{size}")]
        public IEnumerable<Product> GetPage(int ignore, int size )
        {
            try
            {
                var m = new mainn();
                return m.GetPage(ignore, size);
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
