using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace final_project.Models.Entities
{
    public class Payment_method
    {
        public string id{get;set;}
        public string name{get;set;}
        public ICollection<Order> Orders{get;set;}
    }
}