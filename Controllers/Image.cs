
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using final_project;
using final_project.Models.Entities;
using final_project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting.Internal;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 public class ImageController :ControllerBase
    {
        string rootPath;
        public static IHostingEnvironment _environment;
      public  ImageController(IHostingEnvironment environment)
        {
         _environment = environment;
        }

     [HttpGet("{name}")]
      public async Task<IActionResult> Get(string name)
      {
      var image = System.IO.File.OpenRead("C:\\Users\\kieu\\Desktop\\final_project\\final_project\\assets\\"+name);
      return File(image, "image/jpg");
      }
     

   
        [HttpPost]
        public async Task<string> Post( [FromForm] IFormFile file)
        {
            
                try
                {
                    if (!Directory.Exists(_environment.ContentRootPath + "\\assets\\"))
                    {
                        Directory.CreateDirectory(_environment.ContentRootPath+ "\\assets\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_environment.ContentRootPath + "\\assets\\" + file.FileName))
                    {
                        file.CopyTo(filestream);
                        filestream.Flush();
                        return "\\assets\\" + file.FileName;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            
           
        }
    }
    }

