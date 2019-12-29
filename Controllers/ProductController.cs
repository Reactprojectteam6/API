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
        public ActionResult<dynamic> Get() //get list
        {  
            return _productservice.GetProducts();
        }

        [HttpGet("{id}")]   //get sv
        public ActionResult<dynamic> Get(string id)
        { 
            return _productservice.GetProductById(id);
        }

        [HttpDelete("{id}")] //delete sv
        public void Delete(string  id)
        {
           _productservice.DeleteProduct(id);
        }
     
         [HttpGet("Name={name}")]
        public ActionResult<IEnumerable<Product>> GetProductByName(string name) //get list
        {  
            return _productservice.GetProductsByName(name);
        }
       
       [HttpGet("{name}/Colors")]
        public ActionResult<IEnumerable<Color>> GetColor(string name) //get list
        {  
            return _productservice.GetColors(name);
        }
        //update so luong
        [HttpPut("{id}")]  //update sv
        public void Put([FromBody] Product product)
        {   
           _productservice.UpdateProduct(product);
             
        }
       [HttpGet("{id}/Rating")]
        public ActionResult<int> GetRating(string  id) //get list
        {  
            return _productservice.GetRating(id);

        }
        [HttpGet("{name}/{color}/{shop_id}")]
        public ActionResult<dynamic> GetProductByNameAndColor(string name,string color,string  shop_id) //get list
        {  
            return _productservice.GetProductByNameAndColor(name,color,shop_id);

        }
         [HttpGet("Rating/{a}-{b}")]
        public ActionResult<IEnumerable<Product>> GetProductByRating(int a,int b) //get list
        {  
            return _productservice.GetProductByRating(a,b);

        }
          [HttpGet("Hot")]
        public ActionResult<IEnumerable<Product>> GetHotProduct() //get list
        {  
            return _productservice.GetHotProduct();

        }
        [HttpGet("Rating/{id}")]//get list_order_detail_to_rating
          public ActionResult<IEnumerable<Product>> GetProductToRating(string id) //get list
        {    var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
             var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
             
        
        var ID=tokenS.Claims.First(claim => claim.Type =="ID").Value;
        if(ID==id)
            return _productservice.GetListProductToRating(id);
            else return BadRequest();

        }
          
        //shop
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
         [HttpPost]  //tao sv
        public void Post([FromBody] dynamic product)
        {    
             _productservice.AddProduct(product);
           
        }
         
        [HttpPut("{id}/shop")]  //update sv
        public void Put(string id, [FromBody] Product product)
        {        var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
             var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
             
        
        var Role=tokenS.Claims.First(claim => claim.Type =="Role").Value;
        var Shop_ID=tokenS.Claims.First(claim => claim.Type =="Shop_ID").Value;
         if(Role=="Shop"&&Shop_ID==id)
           _productservice.UpdateProductShop(id,product);
             
        }
        [HttpGet("Shop/{shop_id}/ProductName={name}")]
        [Authorize]
        public ActionResult<dynamic> getProductShopByName(string shop_id,string name)
        {
            return _productservice.getProductOnShopByName(shop_id,name);
        }
    }
}