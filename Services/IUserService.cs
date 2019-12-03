
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
        public void UpdateUser(string id,User user);
        public void DeleteUser(string id);
        public User CheckLoginUser(string email,string password);
        public User GetUserByEmail(string email);
      


    }
}