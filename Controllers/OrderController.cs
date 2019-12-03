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
    public class OrderController : ControllerBase
    {   
        private IOrderService _orderService;
        private DataContext _context;
        public OrderController(IOrderService _order, DataContext context){
            this._orderService =_order;
            _context = context;
        }
       

        [HttpPost]
        public Order Post([FromBody] Order order)
        {  return   _orderService.AddOrder(order);
        }

      
    }
}