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
        { 
              
            //throw new NotImplementedException();
        }
         public dynamic GetAllShop()
         { var s=_context.Shops.Where(p=>p.User.permission==true).Select(p=>new{p.id,p.shop_name,p.User.user_name,p.User.email,p.User.phone,p.Check_Paid_Shops,p.User.address});
           return s.ToList();
         }
        public dynamic getShopByName(string name)
        { 
          var s=_context.Shops.Where(p=>p.User.permission==true&&p.shop_name.Contains(name)).Select(p=>new{p.id,p.shop_name,p.User.user_name,p.User.email,p.User.phone,p.Check_Paid_Shops,p.User.address});
           return s.ToList();

        }
           public dynamic getPaypal(string id)
           { var s=_context.Shops.Where(p=>p.id==id).Select(p=>new {p.sandbox,p.production}).FirstOrDefault();
             return s;
              
           }

    }
}