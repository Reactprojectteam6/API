using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models.Entities;
using final_project;
namespace final_project.Services
{  
      public class ProductService : IProductService
    {  private DataContext _context;

        public ProductService(DataContext context)
      { _context=context;
      }
        public void AddProduct(Product product)
        {   _context.Products.Add(product);
         _context.SaveChanges();
            //throw new NotImplementedException();
        }

        public bool DeleteProduct(string id){
         
         var s=_context.Order_details.Where(p=>p.product_id==id).Select(p=>p);
         if(s.ToList().Count>0)
         {  
            
           return false;
         }
         else { 
           
            var c=_context.product_Colors.Where(x=>x.product_id==id).Select(p=>p);
           foreach(var i in c.ToList())
         {
            _context.product_Colors.Remove(i);
           _context.SaveChanges();
         }
           
            var product=new Product();

           product=_context.Products.FirstOrDefault(x=>x.id==id);
           _context.Products.Remove(product);
           _context.SaveChanges();
          
      

           return true;

         };

            //throw new NotImplementedException();
        }

        public dynamic GetProductById(string id)
        {   var product=new Product();
            var s= _context.Products.Where(x=>x.id==id).Select(p=>new{p.id,p.image,p.price,p.quantity,p.Shop.name});
            return s.FirstOrDefault();
            
        }

        public List<Product> GetProducts()
        {    var products =new List<Product>();
           products=_context.Products.ToList();
            return products;
           
        }

        public void UpdateProduct(string id, Product product)
        {  
             var old_product=new Product();
             old_product=_context.Products.FirstOrDefault(x=>x.id==id);
             old_product.product_name=product.product_name;
             old_product.description=product.description;
             old_product.cat_id=old_product.cat_id;
             old_product.price=old_product.price;
             old_product.quantity=old_product.quantity;
             old_product.shop_id=old_product.shop_id;
             _context.SaveChanges();
            //throw new NotImplementedException();
        }
          public List<Product> GetProductsByName(string name){
           List<Product> list=new List<Product>();
           var s=_context.Products.Select(p=>p).Where(s=>s.product_name.Contains(name)).Distinct();
           list=s.ToList();
           return list;


          }
              public string GetName(string id){
               
               var s=from p in _context.Products where (p.id==id) select  new {p.Shop.name};
               return s.First().name;
              }
               public List<Color> GetColors()
               {
                 var s=_context.Colors.Select(p=>p);
                 return s.ToList();
               }
        public List<Product> GetProductsOnShop(string shop_id)
        {
            List<Product> list=new List<Product>();
            list=_context.Products.Select(p=>p).Where(s=>s.shop_id==shop_id).ToList();
            return list;
        }
    }
}