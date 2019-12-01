using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace final_project.Models.Entities
{
    public class Color
    {
        public string id{get;set;}
        public string name{get;set;}
        public ICollection<Product_Color> Product_Colors{get;set;}
    }
}