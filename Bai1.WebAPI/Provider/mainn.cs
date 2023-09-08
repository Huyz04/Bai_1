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
        public IEnumerable<Product> GetProducts()
        {
            using (Providers dbContext = new Providers())
            {
                return dbContext.GetProducts();
            }
        }
        public Product GetProducts(int product_id)
        {
            using (Providers dbContext = new Providers())
            {
                return dbContext.GetProducts(product_id).FirstOrDefault();
            }
        }
        public int GetTotal()
        {
            using (Providers dbContext = new Providers())
            {
                return dbContext.GetTotal();
            }
        }
        public IEnumerable<Product> FindProducts(string product_info, string product_type)
        {
            using (Providers dbContext = new Providers()) 
            {
                return dbContext.FindProducts(product_info,product_type);
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