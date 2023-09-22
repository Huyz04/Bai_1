using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bai1.WebAPI.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Bai1.WebAPI.Provider
{

    public class mainn
    {
        public IEnumerable<Product> GetProducts(int Page, int PageSize)
        {
            using (Providers dbContext = new Providers())
            {
                return dbContext.GetProducts(Page, PageSize);
            }
        }
        public Product GetProducts(int product_id)
        {
            using (Providers dbContext = new Providers())
            {
                return dbContext.GetProducts(product_id).FirstOrDefault();
            }
        }
        public int GetTotal(string info, string type)
        {
            using (Providers dbContext = new Providers())
            {
                if (info == null && type == null) 
                    return dbContext.GetTotal("", "");
                else
                return dbContext.GetTotal(info, type);
            }
        }
        public IEnumerable<Product> FindProducts(string product_info, string product_type, int Page, int PageSize)
        {
            using (Providers dbContext = new Providers()) 
            {
                return dbContext.FindProducts(product_info,product_type, Page, PageSize);
            }
        }
        // Paging
        public IEnumerable<Product> GetPage(int Ignore, int Size)
        {
            using (Providers dbContext = new Providers())
            {
                return dbContext.GetPage(Ignore, Size);
            }
        }
        //Posst
        public int InsertProducts(Product prd)
        {
            using (Providers dbContext = new Providers())
            {
                return dbContext.InsertProducts(prd);
            }
        }

        // PUT: api/Bai1/5
        public int UpdateProducts(int product_id, Product prd)
        {
            using (Providers dbContext = new Providers())
            {
                return dbContext.UpdateProducts(product_id, prd);
            }
        }

        // DELETE: api/Bai1/5
        //[Route("{product_id}")]
        public int DeleteProducts(int product_id)
        {
            using (Providers dbContext = new Providers())
            {
                return dbContext.DeleteProducts(product_id);
            }
        }
    }
}