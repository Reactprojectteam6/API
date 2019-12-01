using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models.Entities
{
    public class Product_Size
    {
        public string id{get;set;}
        public string product_id{get;set;}
        public string size_id {get;set;}
        [ForeignKey("product_id")]
        public Product Product{get;set;}
        [ForeignKey("size_id")]
        public Size Size{get;set;}
    }
}