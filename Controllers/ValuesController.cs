using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using  Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace final_project.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    // GET api/values
    [HttpGet]
     [Authorize]
    public IEnumerable<string> Get()
    { 
        return new string[] { "value1", "value2" };

    }
   
}
}