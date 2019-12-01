using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models.Entities
{
    public class Product_Color
    {
        public string id{get;set;}
        public string product_id{get;set;}
        public string color_id{get;set;}
        [ForeignKey("product_id")]
        public Product Product{get;set;}
        [ForeignKey("color_id")]
        public Color Color{get;set;}

    }
}