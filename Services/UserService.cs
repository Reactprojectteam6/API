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
        {    int max=1;
            var s=_context.Users.Select(p=>p.id);
             foreach(var i in s)
             { if(max<int.Parse(i)) max=int.Parse(i);

             }
             user.id=(max+1).ToString();
          _context.Users.Add(user);
          _context.SaveChanges();
            //throw new NotImplementedException();
        }

        public void DeleteUser(string id)
        { //delete shop
          
               var old_user=new User();
               old_user=_context.Users.FirstOrDefault(x=>x.id==id);
               old_user.permission=false;
               _context.SaveChanges();
        }

        public User GetUserById(string id)
        {    var user=new User();
          user=_context.Users.FirstOrDefault(x=>x.id==id);
          return user;
            //throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {   var users=new List<User>();
            users=_context.Users.Where(p=>p.permission==true).ToList();
            return users;
            //throw new NotImplementedException();
        }
          public void UpdateUser( User user)
        {     var old_user=new User();
              old_user=_context.Users.FirstOrDefault(x=>x.id==user.id);
              old_user.user_name =user.user_name;
              old_user.password =user.password;
              old_user.email =user.email;
              old_user.phone =user.phone;
              old_user.role =user.role;
              old_user.address =user.address;
             _context.SaveChanges();
            //throw new NotImplementedException();
        }
           public User CheckLoginUser(string email,string password)
        {    User existUser= new User();
              existUser = _context.Users.FirstOrDefault(u => u.email ==email&&u.password==password);
               if(existUser!=null) return existUser;
               else return existUser;
            
        }
          public User GetUserByEmail(string email){
            
            User existUser= new User();
              existUser = _context.Users.FirstOrDefault(u => u.email ==email);
               if(existUser!=null) return existUser;
               else return existUser;
               
          }
       public List<User> getUserByName(string name)
       {  List<User> list=new List<User>();
          var s=_context.Users.Select(p=>p).Where(s=>s.user_name.Contains(name)&&s.permission==true);
           return s.ToList();
       }
       
    }
}