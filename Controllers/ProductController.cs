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
    public class ProductController : ControllerBase
    {  private IProductService _productservice;

        public ProductController(IProductService productServcie)
      {
          _productservice=productServcie;
      }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get() //get list
        {  
            return _productservice.GetProducts();
        }

        [HttpGet("{id}")]   //get sv
        public ActionResult<Product> Get(string id)
        { 
            return _productservice.GetProductById(id);
        }

        [HttpPost]  //tao sv
        public void Post([FromBody] Product product)
        { _productservice.AddProduct(product);
        }

        [HttpPut("{id}")]  //update sv
        public void Put(string id, [FromBody] Product product)
        {
           _productservice.UpdateProduct(id,product);
             
        }

        [HttpDelete("{id}")] //delete sv
        public void Delete(string id)
        {
           _productservice.DeleteProduct(id);
        }
        
    }
}