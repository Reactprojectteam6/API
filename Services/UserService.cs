using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project;
using final_project.Models.Entities;
using final_project.Services;

namespace final_project.Services
{
    public class UserService : IUserService
    {  private DataContext  _context;
       public UserService(DataContext context)
       {  _context=context;

       }
        public void AddUser(User user)
        {  _context.Users.Add(user);
          _context.SaveChanges();
            //throw new NotImplementedException();
        }

        public void DeleteUser(string id)
        {  var user=new User();
          user=_context.Users.FirstOrDefault(x=>x.id==id);
          _context.Users.Remove(user);
          _context.SaveChanges();
            //throw new NotImplementedException();
        }

        public User GetUserById(string id)
        {    var user=new User();
          user=_context.Users.FirstOrDefault(x=>x.id==id);
          return user;
            //throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {   var users=new List<User>();
            users=_context.Users.ToList();
            return users;
            //throw new NotImplementedException();
        }

        public void UpdateUser(string id, User user)
        {     if (id == user.id)
            {
                _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            //throw new NotImplementedException();
        }
           public User CheckLoginUser(string email,string password)
        {    User existUser= new User();
              existUser = _context.Users.FirstOrDefault(u => u.email ==email && u.password ==password);
              return existUser;

        }
    }
}