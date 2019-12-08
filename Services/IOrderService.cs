using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models.Entities;

namespace final_project.Services
{
    public interface IOrderService
    {
         public dynamic GetOrderByUser(string id);//get order of 1 user
        //public Order GetOrderById(string id);
        public Order AddOrder(Order order);
        public void cancelOrder(string id);
        public void DeleteOrder(string id);
        public dynamic GetOrderByID(string id);
    }
}