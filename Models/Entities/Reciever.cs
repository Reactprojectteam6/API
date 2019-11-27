using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace final_project.Models.Entities
{
    public class Reciever
    {
        public string id {get;set;}
        public string address {get;set;}
        public string email {get;set;}
        public string fullname{get;set;}
        public string phone{get;set;}
        public string order_id{get;set;}
        [ForeignKey("order_id")]
        public Order Order{get;set;}
    }
}