using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace final_project.Models.Entities
{
    public class Order
    {
        public string id {get;set;}
        public DateTime date_create{get;set;}
        public DateTime date_paid{get;set;}
        public int status {get;set;}
        public int total{get;set;}
        public string payment_id{get;set;}
        [ForeignKey("payment_id")]
        public Payment_method Payment_Method{get;set;}
        public string reciever_id{get;set;}
        [ForeignKey("reciever_id")]
        public Reciever Reciever{get;set;}
        public ICollection<Order_detail> Order_Details{get;set;}
        public string user_id{get;set;}
        [ForeignKey("user_id")]
        public User User{get;set;}
    }
}