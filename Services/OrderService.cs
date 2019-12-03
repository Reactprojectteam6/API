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
        public List<Order> GetOrderByUser(string id){
       
        var s=_context.Orders.Where(p=>p.user_id==id).Select(p=>p);
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
        public void UpdateOrder(string id,Order order){
          var old_order=_context.Orders.FirstOrDefault(x=>x.id==id);
            old_order.date_create=order.date_create;
            old_order.date_paid=order.date_paid;
            old_order.status=order.status;
            old_order.total=order.total;
            old_order.payment_id=order.payment_id;
            old_order.receiver_id=order.receiver_id;
            old_order.user_id=order.user_id;
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
            var s=_context.Orders.Where(p=>p.id==id).Select(p=>new{p.Reciever.fullname,p.Payment_Method.name,p.total,p.status,p.date_create});
            return s;
          }
    }
}