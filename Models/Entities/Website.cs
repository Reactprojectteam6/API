
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace final_project.Models.Entities
{
    public class Website
    {
        public string id{get;set;}
        public string address {get;set;}
        public string email {get;set;}
        public string phone {get;set;}
        public string sandbox{get;set;}
        public string production{get;set;}
    }
}