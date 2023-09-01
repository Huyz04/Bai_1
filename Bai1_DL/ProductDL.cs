using Bai1.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1_DL
{
    public class ProductDL
    {
        public IEnumerable<Product> GetProducts() {
            using (DbContext dbContext = new DbContext())
            {
                return dbContext.Getproducts();
            }
        }
        public Product GetProducts(int product_id)
        {
            using (DbContext dbContext = new DbContext())
            {
                return dbContext.Getproducts(product_id).FirstOrDefault();
            }
        }
        //Posst
        public int Post(Product prd)
        {
            using (DbContext dbContext = new DbContext())
            {
                return dbContext.Insertproducts(prd);
            }
        }

        // PUT: api/Bai1/5
        public int Put(int product_id, Product prd)
        {
            using (DbContext dbContext = new DbContext())
            {
                return dbContext.Updateproducts(product_id, prd);
            }
        }

        // DELETE: api/Bai1/5
        //[Route("{product_id}")]
        public int Delete(int product_id)
        {
            using (DbContext dbContext = new DbContext())
            {
                return dbContext.Deleteproducts(product_id);
            }
        }

    }
}
