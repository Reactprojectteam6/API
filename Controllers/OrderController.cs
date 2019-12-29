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

        [HttpGet("user/{id}")]
        [Authorize]
        public ActionResult<dynamic> GetOrderOfUser(string id)
        {  //Get all user chi co admin dc get
             var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
             var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;

          var id1=tokenS.Claims.First(claim => claim.Type =="ID").Value;
          var Role=tokenS.Claims.First(claim => claim.Type =="Role").Value;
          if(id==id1||Role=="Admin")
            return _orderService.GetOrderByUser(id);
            else return BadRequest();
        }
         [HttpGet("{id}")]
        public  ActionResult<dynamic> GetOrderByID(string id)
        {  
           return _orderService.GetOrderByID(id);
           
        
        }
        [HttpPut("{id}/Cancel")]  //update sv
        public void Put( string id)
        {
            _orderService.cancelOrder(id);
             
        }
        //delete order
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(string  id)
        {  //Chi co admin moi dc quyen xoa
        
            _orderService.DeleteOrder(id);
        }
         [HttpGet("Products")]
        public  ActionResult<dynamic> GetProducts()//get list product for order
        {  
           return _orderService.GetListProduct();
        
        }
        //shop buu
          [HttpGet("shop/{shop_id}")]
        public ActionResult<dynamic> GetOrdersOnShop(string shop_id)
        {     


            return _orderService.GetOrdersOnShop(shop_id);
        }
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Order order)
        {
            _orderService.UpdateOrder(id,order);
        }
        
          
      
    }
}