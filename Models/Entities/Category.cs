using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace final_project.Models.Entities
{
    public class Category
    {
        public string id {get;set;}
        public string name{get;set;}
        public string parent_id{get;set;}
         [JsonIgnore] 
        [IgnoreDataMember] 
        [ForeignKey("parent_id")]
        public ICollection<Category> Categories{get;set;}
        
        [JsonIgnore] 
        [IgnoreDataMember] 
        public ICollection<Product> Products{get;set;}
    }
}