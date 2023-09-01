using Bai1.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1_DL
{
    public class DbContext: IDisposable
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        public DbContext()
        {
            string connectionString = "Server=HUYZ04; Database=BAI1; Trusted_Connection=True";
            // khoi tao ket noi
            sqlConnection = new SqlConnection(connectionString);
            //tao Command
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        }

        public IEnumerable<Product> Getproducts()
        {
            //khai bao cau truy van
            sqlCommand.CommandText = "Select_all_product";
            return this.ExcuteReader();
        }
        public IEnumerable<Product> Getproducts(int product_id)
        {
            //khai bao cau truy van
            sqlCommand.CommandText = "Select_ID_product";
            //Gan gia tri cho cac bien 
            sqlCommand.Parameters.AddWithValue("@ID", product_id);
            return this.ExcuteReader();
        }
        public int Insertproducts(Product prd)
        {
            //khai bao cau truy van
            sqlCommand.CommandText = "Insert_product";
            //Gan gia tri cho cac bien 
            sqlCommand.Parameters.AddWithValue("@ID", prd.ID);
            sqlCommand.Parameters.AddWithValue("@Code", prd.Code);
            sqlCommand.Parameters.AddWithValue("@Name", prd.Name);
            sqlCommand.Parameters.AddWithValue("@Category", prd.Category);
            sqlCommand.Parameters.AddWithValue("@Brand", prd.Brand);
            sqlCommand.Parameters.AddWithValue("@Type", prd.Type);
            sqlCommand.Parameters.AddWithValue("@Description", prd.Description);
            //Mo ket noi
            sqlConnection.Open();
            // Thuc thi cong viec voi database
            var result = sqlCommand.ExecuteNonQuery();
            return result;


        }
        public int Updateproducts(int product_id, Product prd)
        {
            //khai bao cau truy van
            sqlCommand.CommandText = "Update_product";
            //Gan gia tri cho cac bien 
            sqlCommand.Parameters.AddWithValue("@ID", product_id);
            sqlCommand.Parameters.AddWithValue("@Code", prd.Code);
            sqlCommand.Parameters.AddWithValue("@Name", prd.Name);
            sqlCommand.Parameters.AddWithValue("@Category", prd.Category);
            sqlCommand.Parameters.AddWithValue("@Brand", prd.Brand);
            sqlCommand.Parameters.AddWithValue("@Type", prd.Type);
            sqlCommand.Parameters.AddWithValue("@Description", prd.Description);
            //Mo ket noi
            sqlConnection.Open();
            // Thuc thi cong viec voi database
            var result = sqlCommand.ExecuteNonQuery();
            return result;
        }
        public int Deleteproducts(int product_id)
        {
            //khai bao cau truy van
            sqlCommand.CommandText = "Delete_product";
            //Gan gia tri cho cac bien 
            sqlCommand.Parameters.AddWithValue("@ID", product_id);
            //Mo ket noi
            sqlConnection.Open();
            // Thuc thi cong viec voi database
            var result = sqlCommand.ExecuteNonQuery();
            return result;
        }
        private IEnumerable<Product> ExcuteReader()
        {
            //Mo ket noi
            sqlConnection.Open();
            // Thuc thi cong viec voi database
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
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
                yield return pro;
            }
        }
        public void Dispose()
        {
            //Dong ket noi
            sqlConnection.Close();
        }
    }
}
