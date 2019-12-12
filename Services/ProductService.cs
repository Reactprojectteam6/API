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
        public void AddProduct(dynamic product)
        { Product p=new Product();
          int max = 1;
          var s = _context.Products.Select(p=>p.id);
          foreach( var i in s)
          {
            if(max< int.Parse(i)) max = int.Parse(i);
          }
          p.id = (max+1).ToString();
          //gan cho doi tuong moi
          p.product_name=product.product_name;
          p.cat_id=product.cat_id;
          p.permission=product.permission;
         p.description=product.description;
         p.price=product.price;
         p.quantity=product.quantity;
         p.shop_id = product.shop_id;
         p.image = product.image;
          _context.Products.Add(p);
         _context.SaveChanges();
         //tao 1 doi tuong product color
         Product_Color product_Color=new Product_Color();
           int max2 = 1;
            var s2 = _context.product_Colors.Select(p=>p.id);
            foreach( var i in s2)
            {
              if(max2< int.Parse(i)) max2 = int.Parse(i);
            }
            product_Color.id = (max2+1).ToString();
            product_Color.product_id=p.id;
            product_Color.color_id=product.color_id;
            _context.product_Colors.Add(product_Color);
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
            var s= _context.Products.Where(x=>x.id==id).Select(p=>new{p.id,p.product_name,p.description,p.cat_id,p.price,p.quantity,p.image,p.shop_id,p.product_Colors.First().Color.name});
            return s;
            
        }

        public List<Product> GetProducts()
        {    var products =new List<Product>();
           products=_context.Products.ToList();
            return products;
           
        }

        public void UpdateProductShop(string id, Product product)
        {  
             var old_product=new Product();
             old_product=_context.Products.FirstOrDefault(x=>x.id==id);
             old_product.product_name=product.product_name;
             old_product.description=product.description;
             old_product.cat_id=product.cat_id;
             old_product.price=product.price;
             old_product.quantity=product.quantity;
             old_product.permission = product.permission;
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
               
               var s=from p in _context.Products where (p.id==id) select  new {p.Shop.shop_name};
               return s.First().shop_name;
              }
               public List<Color> GetColors()
               {
                 var s=_context.Colors.Select(p=>p);
                 return s.ToList();
               }
        public dynamic GetProductsOnShop(string shop_id)
        {
            
            var list=_context.Products.Select(p=>new {p.id,p.product_name,p.shop_id,p.price,p.quantity,p.image,p.Category.name,p.description,p.permission,p.cat_id}).Where(s=>s.shop_id==shop_id);
            return list;
        }

        public dynamic GetProductDetailByID(string id)
        {
            var s = _context.Products.Where(p=>p.id == id).Select(p=>new {p.id,p.Shop.shop_name,p.price,p.quantity,p.description,p.image,p.cat_id,p.product_name,p.permission,p.product_Colors.First().color_id});
            return s; 
        }

        public void UpdatePermission(string id,Product product)
        {
            var old_product=new Product();
            old_product=_context.Products.FirstOrDefault(x=>x.id==id);
            old_product.permission = product.permission;
            _context.SaveChanges();
        }

        public void AddColor(Product_Color product_Color)
        {
            int max2 = 1;
            var s2 = _context.product_Colors.Select(p=>p.id);
            foreach( var i in s2)
            {
              if(max2< int.Parse(i)) max2 = int.Parse(i);
            }
            product_Color.id = (max2+1).ToString();
            _context.product_Colors.Add(product_Color);
            _context.SaveChanges();
        }
    }
}