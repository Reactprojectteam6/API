using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace final_project.Models.Entities
{
    public class Order_detail
    {
        public string id{get;set;}
        public int price{get;set;}
        public string product_id{get;set;}
        [ForeignKey("product_id")]
         [JsonIgnore] 
        [IgnoreDataMember] 
        public Product Product{get;set;}
        public int quantity{get;set;}
        public string order_id{get;set;}
        [ForeignKey("order_id")]
        public Order Order{get;set;}

    }
}