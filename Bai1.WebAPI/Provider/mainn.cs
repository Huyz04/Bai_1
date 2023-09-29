using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using Bai1.WebAPI.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Bai1.WebAPI.Provider
{

    public class mainn
    {
        public Res GetProducts(int Page, int PageSize)
        {
            using (Providers dbContext = new Providers())
            {
                return dbContext.GetProducts(Page, PageSize);
            }
        }
        //public Res GetTest (int Page, int PageSize)
        //{
        //    using (Providers dbContext = new Providers())
        //    {
        //        return dbContext.GetTest(Page, PageSize);
        //    }
        //}
        public String Error(string res)
        {
            return res;
        }
        public Res GetProducts(int product_id)
        {
            using (Providers dbContext = new Providers())
            {
                return dbContext.GetProducts(product_id);
            }
        }
        public Res GetTotal(string info, string type)
        {
            using (Providers dbContext = new Providers())
            {
                if (info == null && type == null) 
                    return dbContext.GetTotal("", "");
                else
                return dbContext.GetTotal(info, type);
            }
        }
        public Res FindProducts(string product_info, string product_type, int Page, int PageSize)
        {
            using (Providers dbContext = new Providers()) 
            {
                return dbContext.FindProducts(product_info,product_type, Page, PageSize);
            }
        }
        // Paging
        
        //Posst
        public Res InsertProducts(Product prd)
        {
            using (Providers dbContext = new Providers())
            {
                return dbContext.InsertProducts(prd);
            }
        }

        // PUT: api/Bai1/5
        public Res UpdateProducts(int product_id, Product prd)
        {
            using (Providers dbContext = new Providers())
            {
                return dbContext.UpdateProducts(product_id, prd);
            }
        }

        // DELETE: api/Bai1/5
        //[Route("{product_id}")]
        public Res DeleteProducts(int product_id)
        {
            using (Providers dbContext = new Providers())
            {
                return dbContext.DeleteProducts(product_id);
            }
        }
    }
}