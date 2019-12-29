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
            var s= _context.Products.Where(x=>x.id==id).Select(p=>new{p.id,p.product_name,p.description,p.cat_id,p.price,p.quantity,p.image,p.shop_id,p.color.color_name,p.Shop.shop_name});
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
              var s=_context.Products.Where(p=>p.product_name==name&&p.permission==true&&p.quantity>0).Select(p=>p.color).ToList();
              if(s!=null) list=s;
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
            
                  var pro= _context.Products.Where(x=>x.product_name==name&&x.permission==true&&x.quantity>0&&x.color.color_name==color).Select(p=>new{p.id,p.product_name,p.description,p.cat_id,p.price,p.quantity,p.image,p.shop_id,p.color.color_name});
                  return pro;
         
            
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
                
                  public List<Product> GetListProductToRating(string id)
                  {  List<Product> list=new List<Product>();
                    var a=_context.Orders.Where(p=>p.user_id==id&&p.status==2).Select(p=>p).ToList();
                    if(a.Count()>=1)
                    {
                    foreach(var i in a)
                    {   
                       var p=_context.Order_details.Where(p=>p.order_id==i.id).Select(p=>p).ToList();
                       if(p.Count()>=1)
                       {
                       foreach(var j in p)
                       {
                        var n=_context.Products.Where(p=>p.id==j.product_id).Select(p=>p).FirstOrDefault();
                        var c=_context.Comments.Where(p=>p.user_id==id&&p.product_id==n.id).ToList();
                        if(c.Count()<1)
                        list.Add(n);
                       }
                       }
                       
                    }
                    }
                    return list;
                  }
            //shop    

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
         p.image=product.image;
         p.color_id=product.color_id;
        _context.Products.Add(p);
         _context.SaveChanges();
         //tao 1 doi tuong product color
          
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
            var s = _context.Products.Where(p=>p.id == id).Select(p=>new {p.id,p.Shop.shop_name,p.price,p.quantity,p.description,p.image,p.cat_id,p.product_name,p.permission,p.color_id});
            return s; 
        }

        public void UpdatePermission(string id,Product product)
        {
            var old_product=new Product();
            old_product=_context.Products.FirstOrDefault(x=>x.id==id);
            old_product.permission = product.permission;
            _context.SaveChanges();
        }
         public dynamic getProductOnShopByName(string shop_id,string name)
         {
            var list=_context.Products.Select(p=>new {p.id,p.product_name,p.shop_id,p.price,p.quantity,p.image,p.Category.name,p.description,p.permission,p.cat_id}).Where(s=>s.shop_id==shop_id&&s.product_name.Contains(name));
            return list;
         }


             }
    
}