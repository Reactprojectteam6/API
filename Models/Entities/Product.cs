using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace final_project.Models.Entities
{
    public class Product
    {
        public string id{get;set;}
        public string product_name{get;set;}
        public string description{get;set;}
        public string cat_id{get;set;}
        public int price{get;set;}
        public int quantity{get;set;}
        public string image {get;set;}
        public string shop_id {get;set;}
        public bool permission{get;set;}
        [ForeignKey("cat_id")]
        public Category Category{get;set;}
        [ForeignKey("shop_id")]
       
        public Shop Shop{get;set;}
        public ICollection<Product_Color> product_Colors {get;set;}
        
    }
}