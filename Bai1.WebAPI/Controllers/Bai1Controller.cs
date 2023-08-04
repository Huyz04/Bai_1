using Bai1.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Bai1.WebAPI.Controllers
{
    [RoutePrefix("products")]
    public class Bai1Controller : ApiController
    {
        // GET: api/Bai1
        [Route("all")]
        public IEnumerable<Product> Get()
        {
            var products = new List<Product>();
            string connectionString = "Server=HUYZ04; Database=BAI1; Trusted_Connection=True";
            // khoi tao ket noi
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlComman = sqlConnection.CreateCommand();
            //khai bao cau truy van
            sqlComman.CommandText = "SELECT * FROM product;";

            // ket noi database
            sqlConnection.Open();
            // Thuc thi cong viec voi database
            SqlDataReader sqlDataReader = sqlComman.ExecuteReader();
            //Xu ly du lieu
            while (sqlDataReader.Read())
            {
                var pro = new Product();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    //Lay ten cot
                    var colName = sqlDataReader.GetName(i);
                    // Lay gia tri cura cell dang doc
                    var colValue = sqlDataReader.GetValue(i);
                    //Lay ra property giong voi ten cot
                    var property = pro.GetType().GetProperty(colName);
                    // Neu co property tuong ung voi ten cot thi gan du lieu tuong ung
                    if (property != null && colValue != DBNull.Value)
                    {
                        property.SetValue(pro, colValue);
                    }
                }
                //Them doi tuong vao list
                products.Add(pro);
            }
            //Dong Ket noi
            sqlConnection.Close();
            return products;
        }

        // GET: api/Bai1/5
        [Route("{product_id}")]
        public object Get(int  product_id)
        {
            var prd = Product.product.Where(e => e.ID == product_id).FirstOrDefault();
            return prd;
        }

        // POST: api/Bai1 
        [Route("")]
        public bool Post([FromBody]Product prd)
        {
            Product.product.Add(prd);
            return true;
        }

        // PUT: api/Bai1/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bai1/5
        public void Delete(int id)
        {
        }
    }
}
