using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace final_project.Models.Entities
{
    public class Shop
    {
        public string id {get;set;}
        public  string shop_name{get;set;}
        public string payment_account{get;set;}
        public string user_id{get;set;}
        public string address{get;set;}
        public string email {get;set;}
        public string sandbox{get;set;}
        public string production {get;set;}
        [ForeignKey("user_id")]
        public User User{get;set;}
        public ICollection<Check_paid_shop> Check_Paid_Shops{get;set;}
         [JsonIgnore] 
        [IgnoreDataMember] 
        public ICollection<Product> Products{get;set;}
        public ICollection<Order> Orders{get;set;}
    }
}