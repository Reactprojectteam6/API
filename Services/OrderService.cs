using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models.Entities;

namespace final_project.Services
{
    public class OrderService:IOrderService
    { //get order of 1 user
       private DataContext  _context;
       public OrderService(DataContext context)
       {  _context=context;

       }
        public dynamic GetOrderByUser(string id){
        var s=_context.Orders.Where(p=>p.user_id==id).Select(p=>new{p.id,p.date_create,p.status,p.total,p.Payment_Method.name,p.Order_Details}).OrderByDescending(p=>p.date_create);
        return s.ToList();
        }
          
        public Order GetOrderById(string  id)
        { var s=_context.Orders.Where(p=>p.id==id).Select(p=>p).FirstOrDefault();
        return s;

        }
        public Order AddOrder(Order order){
            int max=1;
            var s=_context.Orders.Select(p=>p.id);
             foreach(var i in s)
             { if(max<int.Parse(i)) max=int.Parse(i);

             }
             order.id=(max+1).ToString();
             _context.Orders.Add(order);
             _context.SaveChanges();
             return order;
        }
        public void cancelOrder(string id){
          var old_order=_context.Orders.FirstOrDefault(x=>x.id==id);
            old_order.status=3;
             old_order.date_create=old_order.date_create;
             old_order.date_paid=old_order.date_paid;
             old_order.total=old_order.total;
             old_order.payment_id=old_order.payment_id;
             old_order.receiver_id=old_order.receiver_id;
             old_order.user_id=old_order.user_id;
             old_order.shop_id=old_order.shop_id;
           _context.SaveChanges();

        }
        public void DeleteOrder(string id){
             var order=new Order();
          order=_context.Orders.FirstOrDefault(x=>x.id==id);
          _context.Orders.Remove(order);
          _context.SaveChanges();
        }
          public dynamic GetOrderByID(string id)
          {
            var s=_context.Orders.Where(p=>p.id==id).Select(p=>new{p.Reciever.fullname,p.Payment_Method.name,p.total,p.status,p.date_create,p.Reciever.phone,p.Reciever.address});
            return s;
          }
           public dynamic GetListProduct()
           {   var products =new List<Product>();
            products=_context.Products.Where(p=>p.quantity>0).ToList();
            return products;

           }
           //shop
          public dynamic GetOrdersOnShop(string shop_id)
          {
            var s = _context.Orders.Where(p=>p.shop_id==shop_id).Select(p=>new{p.id,p.date_create,p.date_paid,p.status,p.total,p.User.user_name,p.Reciever.fullname,p.Order_Details,p.Payment_Method.name}).OrderByDescending(g=>g.date_create);
            return s;
          }
            public void UpdateOrder(string id,Order order){
          var old_order=_context.Orders.FirstOrDefault(x=>x.id==id);
            old_order.date_paid=order.date_paid;
            old_order.status=order.status;
           _context.SaveChanges();

        }
    }
}