using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project;
using final_project.Models.Entities;
using final_project.Services;

namespace final_project.Services
{
    public class ShopService : IShopService
    {  
       private DataContext  _context;
       public ShopService(DataContext context)
       {  _context=context;

       }
        public void Delete(string id)
        { var s=_context.Orders.Where(p=>p.shop_id==id).Select(p=>p.id);
         if(s.ToList().Count>0)
          foreach(var i in s.ToList())
          { var o=_context.Order_details.Where(p=>p.order_id==i).Select(p=>p.id);
              if (o.ToList().Count>0)
              {
               foreach(var j in o.ToList())
                 {var Order_detail=new Order_detail();
                 Order_detail=_context.Order_details.FirstOrDefault(x=>x.id==j);
                 _context.Order_details.Remove(Order_detail);
               _context.SaveChanges();
                 }
               
              }

                 var order=new Order();
                 order=_context.Orders.FirstOrDefault(x=>x.id==i);
                 _context.Orders.Remove(order);
               _context.SaveChanges();   

          }

        
          var pro=_context.Products.Where(p=>p.shop_id==id).Select(p=>p.id);
          if(pro.ToList().Count>0)
          { foreach(var k in pro.ToList())
             { var productColor=_context.product_Colors.Where(p=>p.product_id==k).Select(p=>p.id);
                foreach(var n in productColor.ToList())
                 {var pc=new Product_Color();
                   pc=_context.product_Colors.FirstOrDefault(x=>x.id==n);
                 _context.product_Colors.Remove(pc);
                 _context.SaveChanges();


                 }
                 var product=new Product();
                 product=_context.Products.FirstOrDefault(x=>x.id==k);
                 _context.Products.Remove(product);
               _context.SaveChanges(); 
             }


          }
          var check_paid=_context.Check_Paid_Shops.Where(p=>p.shop_id==id).Select(p=>p.id);
          if(check_paid.ToList().Count>0)
          { foreach( var i in check_paid.ToList())
            { var c=new Check_paid_shop();
                 c=_context.Check_Paid_Shops.FirstOrDefault(x=>x.id==i);
                 _context.Check_Paid_Shops.Remove(c);
               _context.SaveChanges(); 

            }



          }  
            
            
          var shop=new Shop();
          shop=_context.Shops.FirstOrDefault(x=>x.id==id);
          _context.Shops.Remove(shop);
          _context.SaveChanges();
              
            //throw new NotImplementedException();
        }

        public string getShopOfUser(string id)
        {
             var s=_context.Shops.Where(p=>p.user_id==id).Select(p=>p.id);
             return s.First();
            //throw new NotImplementedException();
        }
         public dynamic GetAllShop()
         { var s=_context.Shops.Select(p=>new{p.name,p.User.user_name,p.User.email,p.User.phone,p.Check_Paid_Shop.date_paid,p.Check_Paid_Shop.date_expired,p.Check_Paid_Shop.money});
           return s.ToList();
         }
        public dynamic getShopByName(string name)
        { 
          var s=_context.Shops.Select(p=>p).Where(s=>s.name.Contains(name));
           return s.ToList();

        }

    }
}