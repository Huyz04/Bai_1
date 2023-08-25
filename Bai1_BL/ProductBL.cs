using Bai1_Entity;
using Bai1_DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1_BL
{
    public class ProductBL
    {
        public IEnumerable<Product> GetProducts()
        {
            var productDL = new ProductDL();
            var products = productDL.GetProducts();
            return products;
        }
        public Product GetProducts(int prd_id)
        {
            var productDL = new ProductDL();
            var products = productDL.GetProducts(prd_id);
            return products;
        }

        public int UpdateProducts(Product prd)
        {
            var productDL = new ProductDL();
            //Kiem tra trung ma

            //Goi DL lay du lieu  
            return productDL.Post(prd);
        }
        public int  UpdateProducts(int prd_id,Product prd)
        {
            var productDL = new ProductDL();
            //Kiem tra trung ma

            //Goi DL lay du lieu  
            return productDL.Put(prd_id, prd);
        }
        public int DeleteProducts(int prd_id)
        {
            var productDL = new ProductDL();
            //Goi DL lay du lieu  
            return productDL.Delete(prd_id);
        }
    }
}
