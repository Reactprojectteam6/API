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
    public class ShopController : ControllerBase
    {   
        private IShopService _Service;
        private DataContext _context;
        public ShopController(IShopService _shop, DataContext context){
            this._Service=_shop;
            _context = context;
        }
        [HttpGet("user/{id}")]
        [Authorize]
        public ActionResult<string> GetShopOfUser(string id)
        {   var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
             var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;

          var id1=tokenS.Claims.First(claim => claim.Type =="ID").Value;
          var Role=tokenS.Claims.First(claim => claim.Type =="Role").Value;
          if(id==id1||Role=="Admin")
            return _Service.getShopOfUser(id);
            else return BadRequest();
        }
        //delete order
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(string  id)//xoa shop/xoa product/xoa order lien quan den shop
        {  //Chi co admin moi dc quyen xoa
        
            _Service.Delete(id);
        }
     //get all shop
        [HttpGet]
        [Authorize]
        public ActionResult<dynamic> Get()
        {  //Get all user chi co admin dc get
            
             var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
             var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;

        
        var Role=tokenS.Claims.First(claim => claim.Type =="Role").Value;
        if(Role=="Admin")
            return _Service.GetAllShop();
            else return BadRequest();
        }
       [HttpGet("name={name}")]
        [Authorize]
        public ActionResult<dynamic> GetShopByName(string name)
        {  //Get all user chi co admin dc get
            
             var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
             var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;

        
        var Role=tokenS.Claims.First(claim => claim.Type =="Role").Value;
        if(Role=="Admin")
            return _Service.getShopByName(name);
            else return BadRequest();
        }
 
          
      
    }
    
}