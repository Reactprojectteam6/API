using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using final_project;
using final_project.Models.Entities;
using final_project.Services;
namespace final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {  private ICategoryService _categoryservice;

        public CategoryController(ICategoryService categoryServcie)
      {
          _categoryservice=categoryServcie;
      }
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get() //get list
        {  
            return _categoryservice.GetCategories();
        }

        [HttpGet("{id}")]   //get sv
        public ActionResult<Category> Get(string id)
        { 
            return _categoryservice.GetCategoryById(id);
        }

        [HttpPost]  //tao sv
        public void Post([FromBody] Category category)
        { _categoryservice.AddCategory(category);
        }

        [HttpPut("{id}")]  //update sv
        public void Put(string id, [FromBody] Category category)
        {
           _categoryservice.UpdateCategory(id,category);
             
        }

        [HttpDelete("{id}")] //delete sv
        public void Delete(string id)
        {
           _categoryservice.DeleteCategory(id);
        }
        [HttpGet("{id}/subcategory")] //delete sv
          public ActionResult<IEnumerable<Category>> Getsubcategory(string id) //get list
        {  
            return _categoryservice.GetSubCategory(id);
        }
        
    }
}