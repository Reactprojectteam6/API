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

        public void UpdateProduct( Product product)//update so luong sau khi order
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
            //shop    

#region Shop
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

#endregion
             }
    
}