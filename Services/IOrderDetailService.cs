using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models.Entities;

namespace final_project.Services
{
    public interface IOrderDetailService
    { 
      
      public Order_detail AddOrderDetail(Order_detail order);
      public dynamic GetOrderDetailOfOrder(string id);
      public void DeleteOrderDetail(string id);
    }
}