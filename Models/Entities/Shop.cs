using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace final_project.Models.Entities
{
    public class Shop
    {
        public string id {get;set;}
        public  string name{get;set;}
        public string payment_accont{get;set;}
        public string user_id{get;set;}
        public string address{get;set;}
        public string email {get;set;}
        [ForeignKey("user_id")]
        public User User{get;set;}
        public Check_paid_shop Check_Paid_Shop{get;set;}
        public ICollection<Product> Products{get;set;}
    }
}