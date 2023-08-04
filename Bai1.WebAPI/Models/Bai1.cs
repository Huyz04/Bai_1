using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai1.WebAPI.Models
{
    public class Product
    {
        public static List<Product> product = new List<Product>()
        {
            new Product() { ID = 1, Code = "P01", Name = "IP 11", Category =" 128 GB", Brand = "Apple", Type = "11", Description ="IP 11 128 GB" },
            new Product() { ID = 2, Code = "P01", Name = "IP 11", Category =" 128 GB", Brand = "Apple", Type = "11", Description ="IP 11 128 GB" },
            new Product() { ID = 3, Code = "P01", Name = "IP 11", Category =" 128 GB", Brand = "Apple", Type = "11", Description ="IP 11 128 GB" },
            new Product() { ID = 4, Code = "P01", Name = "IP 11", Category =" 128 GB", Brand = "Apple", Type = "11", Description ="IP 11 128 GB" },
            new Product() { ID = 5, Code = "P01", Name = "IP 11", Category =" 128 GB", Brand = "Apple", Type = "11", Description ="IP 11 128 GB" },
            new Product() { ID = 6, Code = "P01", Name = "IP 11", Category =" 128 GB", Brand = "Apple", Type = "11", Description ="IP 11 128 GB" }
        };
        public int ID { get; set; }
        public string Code { get; set; }    
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }   
    }

}