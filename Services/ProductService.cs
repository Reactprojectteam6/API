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
            var s= _context.Products.Where(x=>x.id==id).Select(p=>new{p.id,p.product_name,p.description,p.cat_id,p.price,p.quantity,p.image,p.shop_id,p.product_Colors.First().Color.name,p.Shop.shop_name});
            return s;
            
        }

        public dynamic GetProducts()
        {    var products =new List<Product>();
            products=_context.Products.Where(p=>p.Shop.User.permission==true&&p.permission==true&&p.quantity>0).ToList();
            return products.GroupBy(p=>p.product_name).Select(p=>p.FirstOrDefault()).ToList();
             
        }

        public void UpdateProduct( Product product)
        {  
             var old_product=new Product();
             old_product=_context.Products.FirstOrDefault(x=>x.id==product.id);
             old_product.product_name=product.product_name;
             old_product.description=product.description;
             old_product.cat_id=product.cat_id;
             old_product.price=product.price;
             old_product.quantity=product.quantity;
             old_product.shop_id=product.shop_id;
             _context.SaveChanges();
            //throw new NotImplementedException();
        }
          public List<Product> GetProductsByName(string name){
           List<Product> list=new List<Product>();
           var s=_context.Products.Select(p=>p).Where(s=>s.product_name.Contains(name)).Where(p=>p.Shop.User.permission==true&&p.permission==true&&p.quantity>0).ToList();
           return s.GroupBy(p=>p.product_name).Select(p=>p.FirstOrDefault()).ToList();
          }
           public List<Color> GetColors(string name)
            { List<Color> list=new List<Color>();
              var s=_context.Products.Where(p=>p.product_name==name&&p.permission==true&&p.quantity>0).Select(p=>p.id);
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
             public dynamic GetProductByNameAndColor(string name,string color,string shop_id){
              dynamic a=new object();
             var s1=_context.Colors.Where(p=>p.name==color).Select(p=>p.id);
             var s=_context.product_Colors.Where(p=>p.color_id==s1.First()).Select(p=>p.Product);
             foreach(var i in s.ToList())
             {
               if(i.product_name==name&&i.shop_id==shop_id) {
                  var pro= _context.Products.Where(x=>x.id==i.id &&x.permission==true&&x.quantity>0).Select(p=>new{p.id,p.product_name,p.description,p.cat_id,p.price,p.quantity,p.image,p.shop_id,p.product_Colors.First().Color.name});
                  return pro;
             }
             }
             return a;
            
             }


              public List<Product> GetProductByRating(int a,int b)
              {
               int sum=0;
               int count=0;
               List<Product> products=new List<Product>();
               var s=_context.Products.Select(p=>p);
               foreach(var i in s.ToList())
               {  var comments=_context.Comments.Select(p=>p).Where(p=>p.product_id==i.id&&p.Product.Shop.User.permission==true&&p.Product.permission==true&&p.Product.quantity>0);
                   foreach(var j in comments.ToList())
                   {  sum+=j.rate;
                      count++;

                   }
                   if(count!=0)  if(sum/count>=a&&sum/count<=b) products.Add(i);
                    count=0;
                    sum=0;

               }
             return products;

              }
                public List<Product> GetHotProduct(){
                 
                int sum=0;
               int count=0;
               List<Product> products=new List<Product>();
               var s=_context.Products.Select(p=>p);
               foreach(var i in s.ToList())
               {  var comments=_context.Comments.Select(p=>p).Where(p=>p.product_id==i.id&&p.Product.Shop.User.permission==true&&p.Product.permission==true&&p.Product.quantity>0);
                   foreach(var j in comments.ToList())
                   {  sum+=j.rate;
                      count++;

                   }
                   if(count!=0)  if(sum/count>=4&&sum/count<=5) products.Add(i);
                    count=0;
                    sum=0;

               }
             return products;
                }
             }
    
}