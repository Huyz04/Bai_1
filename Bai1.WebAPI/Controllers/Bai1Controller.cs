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
using System.Threading.Tasks;


namespace Bai1.WebAPI.Controllers
{
    [RoutePrefix("products")]
    public class Bai1Controller : ApiController
    {
        // GET: api/Bai1
        [Route("all")]
        public Res Get([FromUri] int Page, [FromUri] int PageSize )
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
        public Res Get(int  product_id)
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
        ////GET TEST

        //[Route("test")]
        //public Res GetTest([FromUri] int Page, [FromUri] int PageSize)
        //{
        //    try
        //    { 
        //    var n = new mainn();
        //        return n.GetTest(Page, PageSize);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        // GET total
        [Route("total")]
        public Res GetTotal([FromUri] string info, [FromUri] string type)
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
        public Res GetFind([FromUri] string product_info, [FromUri] string product_type, [FromUri] int Page, [FromUri] int PageSize)
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
        public Res Post([FromBody]Product prd)
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
        public Res Put(int product_id, [FromBody]Product prd)
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
        public Res Delete(int product_id)
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
