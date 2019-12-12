using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using final_project;
using final_project.Models.Entities;
using final_project.Services;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

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
        public ActionResult<dynamic> Get(string id)
        { 
            return _productservice.GetProductById(id);
        }

        [HttpPost]  //tao sv
        public void Post([FromBody] dynamic product)
        { _productservice.AddProduct(product);
        }

        [HttpPut("{id}/shop")]  //update sv
        public void Put(string id, [FromBody] Product product)
        {
           _productservice.UpdateProductShop(id,product);
             
        }

        [HttpDelete("{id}")] //delete sv
        public IActionResult Delete(string id)
        { if( _productservice.DeleteProduct(id)==true) return StatusCode(200);
           else return BadRequest();
          
        }
     
         [HttpGet("Name={name}")]
        public ActionResult<IEnumerable<Product>> GetProductByName(string name) //get list
        {  
            return _productservice.GetProductsByName(name);
        }
        [HttpGet("{id}/Shop")]
        public ActionResult<string> GetSize(string id) //get list
        {  
            return _productservice.GetName(id);
        }
       [HttpGet("Colors")]
        public ActionResult<IEnumerable<Color>> GetColor() //get list
        {  
            return _productservice.GetColors();
        }
        [HttpGet("Shop/{shop_id}")]
        [Authorize]
        public ActionResult<dynamic> GetProductsOnShop(string shop_id)
        {
            return _productservice.GetProductsOnShop(shop_id);
        }
        [HttpGet("{id}/detail")]
        public ActionResult<dynamic> GetProductDetailByID(string id)
        {
            return _productservice.GetProductDetailByID(id);
        }
        [HttpPut("{id}/permission")]
        public void UpdatePermission(string id, [FromBody] Product product)
        {
            _productservice.UpdatePermission(id,product);
        }
        
    }
}