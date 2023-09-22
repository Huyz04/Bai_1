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
        public IEnumerable<Product> Get([FromUri] int Page, [FromUri] int PageSize )
        {
            try
            {
                var m  = new mainn();
                return m.GetProducts(Page,PageSize);
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
        //GET TEST

        [Route("test")]
        public IHttpActionResult GetTest()
        {
            var productss = new Product[]
            {
                new Product() { ID = 1, Code = "P01", Name = "IP 11", Category =" 128 GB", Brand = "Apple", Type = "11", Description ="IP 11 128 GB" },
                new Product() { ID = 2, Code = "P01", Name = "IP 11", Category =" 128 GB", Brand = "Apple", Type = "11", Description ="IP 11 128 GB" },
                new Product() { ID = 3, Code = "P01", Name = "IP 11", Category =" 128 GB", Brand = "Apple", Type = "11", Description ="IP 11 128 GB" },
                new Product() { ID = 4, Code = "P01", Name = "IP 11", Category =" 128 GB", Brand = "Apple", Type = "11", Description ="IP 11 128 GB" },
                new Product() { ID = 5, Code = "P01", Name = "IP 11", Category =" 128 GB", Brand = "Apple", Type = "11", Description ="IP 11 128 GB" },
                new Product() { ID = 6, Code = "P01", Name = "IP 11", Category =" 128 GB", Brand = "Apple", Type = "11", Description ="IP 11 128 GB" }
            };
            Res m = new Res
            {
                Response = "Success",
                Data = productss,
                Page = 1,
                PageSize = 5,
                Total = productss.Length
            };

            return Ok(m);
        }

        // GET total
        [Route("total")]
        public int GetTotal([FromUri] string info, [FromUri] string type)
        {
            try
            {
                var m = new mainn();
                return m.GetTotal(info, type);
            }
            catch (Exception)     
            {
                throw;
            }

        }

        // GET: api/Bai1/Name/Namee
        [Route("find")]
        public IEnumerable<Product> GetFind([FromUri] string product_info, [FromUri] string product_type, [FromUri] int Page, [FromUri] int PageSize)
        {
            try
            {
                var m = new mainn();
                return m.FindProducts(product_info, product_type, Page, PageSize) ;
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
