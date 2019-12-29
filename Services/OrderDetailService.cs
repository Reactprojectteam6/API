using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models.Entities;

namespace final_project.Services
{
    public class OrderDetailService : IOrderDetailService
    {  
          private DataContext  _context;
       public OrderDetailService(DataContext context)
       {  _context=context;

       }
     public Order_detail AddOrderDetail(Order_detail order)
        {   
           int max=1;
            var s=_context.Order_details.Select(p=>p.id);
             foreach(var i in s)
             { if(max<int.Parse(i)) max=int.Parse(i);

             }
             order.id=(max+1).ToString();
             _context.Order_details.Add(order);
             _context.SaveChanges();
             return order;
             
        }
        public dynamic GetOrderDetailOfOrder(string id)
        {
            var s=_context.Order_details.Where(p=>p.order_id==id).Select(p=>new{p.Product.product_name,p.quantity,p.price,p.id,p.Product.color.color_name,p.Product.Shop.shop_name});
            return s;

        }
        public void DeleteOrderDetail(string id)
         { var Order_detail=new Order_detail();
            Order_detail=_context.Order_details.FirstOrDefault(x=>x.id==id);
           _context.Order_details.Remove(Order_detail);
           _context.SaveChanges();
        }
    }
}