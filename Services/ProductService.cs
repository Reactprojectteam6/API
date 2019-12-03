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

        public void DeleteProduct(string id)
        {  var product=new Product();
           product=_context.Products.FirstOrDefault(x=>x.id==id);
           _context.Products.Remove(product);
           _context.SaveChanges();
            //throw new NotImplementedException();
        }

        public dynamic GetProductById(string  id)
        {   var product=new Product();
            var s= _context.Products.Where(x=>x.id==id).Select(p=>p);
            return s.FirstOrDefault();
            
        }

        public List<Product> GetProducts()
        {    var products =new List<Product>();
           products=_context.Products.ToList();
            return products.GroupBy(p=>p.product_name).Select(p=>p.FirstOrDefault()).ToList();
           
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
           var s=_context.Products.Select(p=>p).Where(s=>s.product_name.Contains(name)).ToList();
           return s.GroupBy(p=>p.product_name).Select(p=>p.FirstOrDefault()).ToList();
          }
              public string GetName(string id){
               
               var s=from p in _context.Products where (p.id==id) select  new {p.Shop.name};
               return s.First().name;
              }
               public List<Color> GetColors(string name)
               { List<Color> list=new List<Color>();
                 var s=_context.Products.Where(p=>p.product_name==name).Select(p=>p.id);
                 foreach( var i in s.ToList())
                 { var c=_context.product_Colors.Where(p=>p.product_id==i).Select(p=>p.Color);
                    list.Add(c.First());
                     
                     
                 }
                 return list;
               }
              
                 public int GetRating(string id){
                    int sum=0;
                    int count=0;
                   var s=_context.Comments.Select(p=>p).Where(p=>p.product_id==id);
                   foreach(var i in s)
                   {  sum+=i.rate;
                      count++;

                   }
                   if(count!=0) return sum/count;
                   else return 0;
                 }
             public Product GetProductByNameAndColor(string name,string color,string shop_id){
              Product product=new Product();
             var s1=_context.Colors.Where(p=>p.name==color).Select(p=>p.id);
             var s=_context.product_Colors.Where(p=>p.color_id==s1.First()).Select(p=>p.Product);
             foreach(var i in s.ToList())
             {
               if(i.product_name==name&&i.shop_id==shop_id) return i;
             }
             return product;
             }
             }
    
}