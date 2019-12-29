using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models.Entities;

namespace final_project.Services
{
    public interface IShopService
    {       public void Delete(string id);
       public dynamic GetAllShop();
       public dynamic getShopByName(string name);
       public dynamic getPaypal(string id);
       public dynamic getPaymentOfShop(string id);
       public dynamic getPayPalWeb();
       public Check_paid_shop createBilltoPayforShop(Check_paid_shop check_Paid_Shop);

    }
}