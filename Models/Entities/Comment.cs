using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace final_project.Models.Entities
{
    public class Comment
    {
        public string id{get;set;}
        public string contents{get;set;}
        public string product_id{get;set;}
        [ForeignKey("product_id")]
        public Product Product{get;set;}
        public string user_id{get;set;}
        [ForeignKey("user_id")]
        public User User{get;set;}
    }
}