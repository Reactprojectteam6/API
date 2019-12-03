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
    public class ReceiverController : ControllerBase
    {   
        private IReceiverService _Service;
        private DataContext _context;
        public ReceiverController(IReceiverService _recei, DataContext context){
            this._Service =_recei;
            _context = context;
        }
       

        [HttpPost]
         public Receiver Post([FromBody] Receiver receiver)
        {  return _Service.AddReceiver(receiver);
        }

      
    }
}