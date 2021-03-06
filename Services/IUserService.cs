
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models.Entities;
namespace final_project.Services
{    public interface IUserService   {    
        public List<User> GetUsers();
        public User GetUserById(string id);
        public void AddUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(string id);
        public User CheckLoginUser(string email,string password);
        public User GetUserByEmail(string email);
        public string GetMaxId();
        public string GetShopID(string id);
        public Shop GetShop(string id);
        public void UpdateShop(string shop_id,Shop newShop);
      
       public List<User> getUserByName(string name);

    }
}