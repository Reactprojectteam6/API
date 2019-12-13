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
    public class UserController : ControllerBase
    {   
        private IUserService _userService;
        private DataContext _context;
        public UserController(IUserService _userService, DataContext context){
            this._userService = _userService;
            _context = context;
        }
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<User>> Get()
        {  //Get all user chi co admin dc get
            
             var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
             var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;

        
        var Role=tokenS.Claims.First(claim => claim.Type =="Role").Value;
        if(Role=="Admin")
            return _userService.GetUsers();
            else return BadRequest();
        }


        [HttpGet("{id}")]
        [Authorize]
        public  ActionResult<User> Get(string id)
        {   //Get user by id chi co user do or admin dc get
            var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
             var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;

        var ID = tokenS.Claims.First(claim => claim.Type =="ID").Value;
        var Role=tokenS.Claims.First(claim => claim.Type =="Role").Value;
        if(ID==id.ToString()||Role=="Admin")
        return _userService.GetUserById(id);
        else return BadRequest();
        }

        [HttpPut("{id}")]
        [Authorize]
        public void Put([FromBody] User user)
        {  //Chi co user do or admin dc update infor
            var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
             var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
   
        var ID = tokenS.Claims.First(claim => claim.Type =="ID").Value;
        var Role=tokenS.Claims.First(claim => claim.Type =="Role").Value;
        if(ID==user.id||Role=="Admin")
            _userService.UpdateUser(user);
        }
         

        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(string  id)
        {  //Chi co admin moi dc quyen xoa
             var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
        var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
        var Role=tokenS.Claims.First(claim => claim.Type =="Role").Value;
        if(Role=="Admin")
            _userService.DeleteUser(id);
        }


        [HttpPost]
        public void Post([FromBody] User user)
        {    //(_userService.GetMaxId())+1;
            _userService.AddUser(user);
        }
        

        [HttpGet("email={email}")]
        [Authorize]
        public ActionResult<User> GetUser(string email)
        {   //Get user by email chi co user do moi duoc quyen get
            var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;

            var ID = tokenS.Claims.First(claim => claim.Type =="ID").Value;
             if(_userService.GetUserByEmail(email).id==ID)
            return _userService.GetUserByEmail(email);
            else return BadRequest();
        }
        [HttpGet("{id}/shop")]
        [Authorize]
        public ActionResult<string> GetShopID(string id)
        {
            return _userService.GetShopID(id);
        }

        [HttpGet("shop/{id}")]
        [Authorize]
        public ActionResult<Shop> GetShop(string id)
        {
            return _userService.GetShop(id);
        }
        [HttpPut("shop/{shop_id}")]
        [Authorize]
        public void UpdateShop(string shop_id,Shop newShop)
        {
            _userService.UpdateShop(shop_id,newShop);
        }
       [HttpGet("name={name}")]
        [Authorize]
        public ActionResult<IEnumerable<User>> GetUserByName(string name)
        {  //Get all user chi co admin dc get
            
             var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
             var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
             
        
        var Role=tokenS.Claims.First(claim => claim.Type =="Role").Value;
        if(Role=="Admin")
            return _userService.getUserByName(name);
            else return BadRequest();
        }

    }


}