using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using final_project.Services;
using final_project.Models.Entities;
using final_project.Controllers;
using final_project;
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
        public ActionResult<IEnumerable<User>> Get()
        {
            return _userService.GetUsers();
        }
        [HttpGet("{id}")]
        public ActionResult<User> Get(string id)
        {   
            return _userService.GetUserById(id);
        }
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] User user)
        {
            _userService.UpdateUser(id,user);
        }
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _userService.DeleteUser(id);
        }
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _userService.AddUser(user);
        }
    }
}