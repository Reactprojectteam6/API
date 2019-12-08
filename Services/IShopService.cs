using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Services
{
    public interface IShopService
    {  public string getShopOfUser(string id);
       public void Delete(string id);
       public dynamic GetAllShop();
       public dynamic getShopByName(string name);
    }
}