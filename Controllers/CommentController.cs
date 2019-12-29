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
    public class CommentController : ControllerBase
    {   
        private ICommentService _commentService;
        private DataContext _context;
        public CommentController(ICommentService _comment, DataContext context){
            this._commentService =_comment;
            _context = context;
        }
       

        [HttpPost]
        public Comment Post([FromBody] Comment comment)
        {  return _commentService.addComment(comment);
        }
        
      
    }
}