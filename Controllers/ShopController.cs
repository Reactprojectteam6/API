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
      
       
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(string  id)//xoa shop/xoa product/xoa order lien quan den shop
        {  //Chi co admin moi dc quyen xoa
        
            _Service.Delete(id);
        }
    
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
        public ActionResult<dynamic> GetShopByName(string name)//Tim kiem shop dua theo ten
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
      //get paypal cua shop

        [HttpGet("Paypal/{id}")]
        [Authorize]
        public ActionResult<dynamic> GetPayPal(string id)
        {  //Get all user chi co admin dc get
            var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
             var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
             
        
        var Role=tokenS.Claims.First(claim => claim.Type =="Role").Value;
        var Shop_ID=tokenS.Claims.First(claim => claim.Type =="Shop_ID").Value;
         if(Role=="Shop"&&Shop_ID==id)
            return _Service.getPaypal(id);
            else return BadRequest();
            
        }
        [HttpGet("Payment/{id}")]//lich su tra phi thanh toan cua shop
        [Authorize]
        public ActionResult<dynamic> getPaymentOfShop(string id)
        {   var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
             var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
             
        
        var Role=tokenS.Claims.First(claim => claim.Type =="Role").Value;
        var Shop_ID=tokenS.Claims.First(claim => claim.Type =="Shop_ID").Value;
         if(Role=="Shop"&&Shop_ID==id)
        
            return _Service.getPaymentOfShop(id);
            else return BadRequest();
            
        }
        [HttpGet("PaypalWeb")]//lay tai khoan paypal cua web de thanh toan
        [Authorize]
        public ActionResult<dynamic>  GetPaypalWeb()
        {  //Get all user chi co admin dc get
            
            return _Service.getPayPalWeb();
            
        }
          [HttpPost("pay/web")]
         public Check_paid_shop Post([FromBody] Check_paid_shop check_Paid_Shop)//tao hoa don khi thah toan cho web
        { return _Service.createBilltoPayforShop(check_Paid_Shop);
        }
        
     
          
      
    }
    
}