using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace final_project.Models.Entities
{
    public class Picture
    {
        public string id{get;set;}
        public string url{get;set;}
        public string product_id{get;set;}
        [ForeignKey("product_id")]
        public Product Product{get;set;}
    }
}