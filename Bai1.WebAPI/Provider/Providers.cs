using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Bai1.WebAPI.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Bai1.WebAPI.Provider
{
    public class Providers : IDisposable
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        public Providers()
        {
            string connectionString = "Server=HUYZ04; Database=BAI1; Trusted_Connection=True";
            // khoi tao ket noi
            sqlConnection = new SqlConnection(connectionString);
            //tao Command
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        }

        public IEnumerable<Product> GetProducts() 
        {
            //khai bao cau truy van
            sqlCommand.CommandText = "Select_all_product";
            return this.excute();
        }
        public  IEnumerable<Product> GetProducts(int product_id)
        {
            //khai bao cau truy van
            sqlCommand.CommandText = "Select_ID_product";
            //Gan gia tri cho cac bien  
            sqlCommand.Parameters.AddWithValue("@ID", product_id);
            return this.excute();
        }
        public IEnumerable<Product> FindProducts(string product_info, string product_type)
        {
            if (product_type == "Name")
            {
                //khai bao cau truy van
                sqlCommand.CommandText = "Find_Product_Name";
                //Gan gia tri cho cac bien  
                sqlCommand.Parameters.AddWithValue("@Name", product_info);
                return this.excute();
            }
            else if (product_type == "Brand")
            {
                //khai bao cau truy van
                sqlCommand.CommandText = "Find_Product_Brand";
                //Gan gia tri cho cac bien  
                sqlCommand.Parameters.AddWithValue("@Brand", product_info);
                return this.excute();
            } 
            else
            {
                return null;
            }
        }
        public int GetTotal()
        {
            //khai bao cau truy van
            sqlCommand.CommandText = "Total";
            //Mo ket noi
            sqlConnection.Open();
            // Thuc thi cong viec voi database
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            int total = 0;

            if (sqlDataReader.Read())
            {
                total = (int)sqlDataReader["TOTAL"];
            }
            return total;
        }
        public IEnumerable<Product> GetPage(int Ignore, int Size)
        {
            //khai bao cau truy van
            sqlCommand.CommandText = "Paging";
            //Gan gia tri cho cac bien  
            sqlCommand.Parameters.AddWithValue("@Ignore", Ignore);
            sqlCommand.Parameters.AddWithValue("@Size", Size);
            return this.excute();
        }
        public int InsertProducts(Product prd)
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
        public int UpdateProducts(int product_id, Product prd)
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
        public int DeleteProducts(int product_id)
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
        public IEnumerable<Product> excute()
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
            sqlConnection.Close();
        }
    }
}