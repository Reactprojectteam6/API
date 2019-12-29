using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using final_project;
using final_project.Models.Entities;
using final_project.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace final_project.Controllers

{
    [ApiController]
   
public class TokenController : ControllerBase
{    private IUserService _userservice; 
       private const string SECRET_KEY = "TQvgjeABMPOwCycOqah5EQu5yyVjpmVG";
    public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));
     public TokenController(IUserService a)
     {
         _userservice=a;
     }
    [AllowAnonymous]
    [HttpGet]
    [Route("api/Token/{email}/{password}")]
    public IActionResult Get(string email, string password)
    {      var user=_userservice.CheckLoginUser(email,password);
           if(user!=null&&user.permission==true)
           { string shop_id=_userservice.GetShopByUser(user.id);
            return new ObjectResult(GenerateToken(user.role.ToString(),user.id,shop_id));
           }
            else
            return new OkResult();
    }

    // Generate a Token with expiration date and Claim meta-data.
    // And sign the token with the SIGNING_KEY
    private string GenerateToken(string role,string id,string shop_id)
    {       string roles="";
       
            if(role=="1") roles="User";
            if(role=="2") roles="Shop";
            if(role=="3") roles="Admin";
           var claims = new List<Claim>();
            claims.Add(new Claim("Role",roles));
            claims.Add(new Claim("ID",id));
            claims.Add(new Claim("Shop_ID",shop_id));
            claims.Add(new Claim("Our_Custom_Claim", "Our custom value"));
            claims.Add(new Claim("Id", "110"));
           var token = new JwtSecurityToken(
            claims:  claims,
            notBefore: new DateTimeOffset(DateTime.Now).DateTime,
            expires:   new DateTimeOffset(DateTime.Now.AddMinutes(600)).DateTime,
            signingCredentials: new SigningCredentials(SIGNING_KEY,
                                                SecurityAlgorithms.HmacSha256)
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
}