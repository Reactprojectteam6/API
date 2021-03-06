
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace final_project.Models.Entities
{
    public class User
    {
        public string id {get;set;}
        public string user_name {get;set;}
        public string password {get; set;}
        public string email {get;set;}
        public string phone {get;set;}

        public int role {get;set;}
        public bool permission{get;set;}
        public string address{get;set;} 
        public ICollection<Comment> Comments{get;set;}
        public Shop Shop{get;set;}
        public ICollection<Order> Orders{get;set;}

    }
}