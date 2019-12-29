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
         { var s=_context.Shops.Select(p=>new{p.id,p.shop_name,p.User.user_name,p.User.email,p.User.phone,p.Check_Paid_Shops,p.User.address});
           return s.ToList();
         }
        public dynamic getShopByName(string name)
        { 
          var s=_context.Shops.Where(p=>p.shop_name.Contains(name)).Select(p=>new{p.id,p.shop_name,p.User.user_name,p.User.email,p.User.phone,p.Check_Paid_Shops,p.User.address});
           return s.ToList();

        }
           public dynamic getPaypal(string id)
           { var s=_context.Shops.Where(p=>p.id==id).Select(p=>new {p.sandbox,p.production}).FirstOrDefault();
             return s;
              
           }
            public dynamic getPaymentOfShop(string id)
            {
              var s=_context.Check_Paid_Shops.Where(p=>p.shop_id==id).Select(p=>new{p.id,p.Shop.shop_name,p.Shop.User.user_name,p.Shop.User.email,p.Shop.User.phone,p.Shop.User.address,p.date_paid,p.date_expired,p.money});
             return s.ToList();
            }
            public dynamic getPayPalWeb()
            { var s=_context.Websites.Select(p=>new {p.sandbox,p.production});
              return s;


            }
            public Check_paid_shop createBilltoPayforShop(Check_paid_shop check)
            { 
             int max=1;
             var s=_context.Check_Paid_Shops.Select(p=>p.id);
             foreach(var i in s.ToList())
             { if(max<int.Parse(i)) max=int.Parse(i);
             }
              check.id=(max+1).ToString();
              var p=_context.Check_Paid_Shops.Where(p=>p.shop_id==check.shop_id).Select(t=>t.id);
              int max1=1;
             foreach(var i in p.ToList())
             { if(max1<int.Parse(i)) max1=int.Parse(i);
             }
             var d=_context.Check_Paid_Shops.Where(p=>p.id==max1.ToString()).Select(p=>p.date_expired).FirstOrDefault();
             if(d==null) check.date_expired=check.date_paid.AddMonths(1);
             else{ check.date_expired=d.AddMonths(1);}
            _context.Check_Paid_Shops.Add(check);
             _context.SaveChanges();
             return check;
            }
          

    }
}