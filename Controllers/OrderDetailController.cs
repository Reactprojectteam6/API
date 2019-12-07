using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using final_project.Services;
using final_project.Models.Entities;
using final_project.Controllers;
using final_project;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace final_project.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderDetailController : ControllerBase
    {   
        private IOrderDetailService _Service;
        private DataContext _context;
        public OrderDetailController(IOrderDetailService _order, DataContext context){
            this._Service =_order;
            _context = context;
        }
       

        [HttpPost]
        public Order_detail Post([FromBody] Order_detail order)
        {  return   _Service.AddOrderDetail(order);
        }
        [HttpGet("Order/{id}")]
        public  ActionResult<dynamic> GetOrderDetailOfOrder(string id)
        {  
           return _Service.GetOrderDetailOfOrder(id);
        
        }

      
    }
}