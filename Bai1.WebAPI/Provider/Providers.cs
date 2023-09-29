using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
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
        public Res GetProducts(int Page, int PageSize)
        {
            var n = new Res();
            //khai bao cau truy van
            sqlCommand.CommandText = "Select_all_product";
            sqlCommand.Parameters.AddWithValue("@Page", Page);
            sqlCommand.Parameters.AddWithValue("@PageSize", PageSize);
            n.Data = this.excute();
            n.Page = Page;
            n.PageSize = 5;
            n.Total = n.Data.Count();
            if (n.Total > 0)
                n.Response = "Success";
            else n.Response = "NULL";
            return n;
        }
        public Res GetProducts(int product_id)
        {
            var n = new Res();
            //khai bao cau truy van
            sqlCommand.CommandText = "Select_ID_product";
            //Gan gia tri cho cac bien  
            sqlCommand.Parameters.AddWithValue("@ID", product_id);
            n.Data = this.excute();
            n.Page = 1;
            n.PageSize = 5;
            n.Total = n.Data.Count();
            if (n.Total > 0)
                n.Response = "Success";
            else n.Response = "NULL";
            return n;
        }
        public Res FindProducts(string product_info, string product_type, int Page, int PageSize)
        {
            var n = new Res();
            //khai bao cau truy van
            sqlCommand.CommandText = "Find_Product";
            //Gan gia tri cho cac bien  
            sqlCommand.Parameters.AddWithValue("@Info", product_info);
            sqlCommand.Parameters.AddWithValue("@Type", product_type);
            sqlCommand.Parameters.AddWithValue("@Page", Page);
            sqlCommand.Parameters.AddWithValue("@PageSize", PageSize);
            n.Data = this.excute();
            n.Page = 1;
            n.PageSize = 5;
            n.Total = n.Data.Count();
            if (n.Total > 0)
                n.Response = "Success";
            else n.Response = "NULL";
            return n;
        }
        public Res GetTotal(string info, string type)
        {
            var n = new Res();
            //khai bao cau truy van
            sqlCommand.CommandText = "Total";
            //Gan gia tri cho cac bien
            sqlCommand.Parameters.AddWithValue("@info", info);
            sqlCommand.Parameters.AddWithValue("@type", type);
            //Mo ket noi
            sqlConnection.Open();
            // Thuc thi cong viec voi database
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            n.Total = 0;
            if (sqlDataReader.Read())
            {
                n.Total = (int)sqlDataReader["TOTAL"];
            }
            n.Data = Enumerable.Empty<Product>();
            n.Page = 0;
            n.PageSize = 0;
            if (n.Total > 0)
                n.Response = "Success";
            else n.Response = "NULL";
            return n;
        }

        public Res InsertProducts(Product prd)
        {
            var x = new Product() ;
            var n = new Res();
            //khai bao cau truy van
            sqlCommand.CommandText = "Insert_product";
            //Gan gia tri cho cac bien 
            sqlCommand.Parameters.AddWithValue("@Name", prd.Name);
            sqlCommand.Parameters.AddWithValue("@Category", prd.Category);
            sqlCommand.Parameters.AddWithValue("@Brand", prd.Brand);
            sqlCommand.Parameters.AddWithValue("@Type", prd.Type);
            sqlCommand.Parameters.AddWithValue("@Description", prd.Description);
            //Mo ket noi
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            n.Page = 0;
            n.PageSize = 0;
            if (sqlDataReader.Read())
            {
                n.Response = "Success";
                x.ID = (int)sqlDataReader["ID"];
                x.Code = (string)sqlDataReader["Code"];
                x.Name = prd.Name;
                x.Category = prd.Category;
                x.Brand = prd.Brand;
                x.Type = prd.Type;
                x.Description = prd.Description;
            }
            else n.Response = "Fail";
            n.Data = new List<Product> { x };
            n.Total = n.Data.Count();
            return n;
        }
        public Res UpdateProducts(int product_id, Product prd)
        {
            var n = new Res();
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
            n.Data = new List<Product> { prd };
            n.Page = 0;
            n.PageSize = 0;
            n.Total = n.Data.Count();
            if (result != 0)
                n.Response = "Success";
            else n.Response = "Fail";
            return n;
        }
        public Res DeleteProducts(int product_id)
        {
            var n = new Res();
            //khai bao cau truy van
            sqlCommand.CommandText = "Delete_product";
            //Gan gia tri cho cac bien 
            sqlCommand.Parameters.AddWithValue("@ID", product_id);
            //Mo ket noi
            sqlConnection.Open();
            // Thuc thi cong viec voi database
            var result = sqlCommand.ExecuteNonQuery();
            n.Data = Enumerable.Empty<Product>();
            n.Page = 0;
            n.PageSize = 0;
            n.Total = result;
            if (result != 0)
                n.Response = "Success";
            else n.Response = "Fail";
            return n;
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
        public string Error (string res)
        {
            return res;
        }

        public void Dispose()
        {
            sqlConnection.Close();
        }
    }
}