using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace final_project.Models.Entities
{
    public class Check_paid_shop
    {
        public string id{get;set;}
        public DateTime date_expired{get;set;}
        public DateTime date_paid{get;set;}
        public int money {get;set;}
        public string shop_id{get;set;}
        [ForeignKey("shop_id")]
        public Shop Shop{get;set;}
    }
}