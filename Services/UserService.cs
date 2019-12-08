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
           var shop_id=_context.Shops.Where(p=>p.user_id==id).Select(p=>p.id).FirstOrDefault();//tim shop of user
           if(shop_id!=null)
           {  
           var s=_context.Orders.Where(p=>p.shop_id==shop_id).Select(p=>p.id); //tim cac order lien quan den shop do
           if(s.ToList().Count>0)
          { 
          foreach(var i in s.ToList())
          { var o=_context.Order_details.Where(p=>p.order_id==i).Select(p=>p.id);//tim cac order detail of shop do
              if (o.ToList().Count>0)                                           //xoa cac order detail
              {
               foreach(var j in o.ToList())
                 {var Order_detail=new Order_detail();
                 Order_detail=_context.Order_details.FirstOrDefault(x=>x.id==j);
                 _context.Order_details.Remove(Order_detail);
               _context.SaveChanges();
                 }
               
              }

                 var order=new Order();                                //xoa cac order 
                 order=_context.Orders.FirstOrDefault(x=>x.id==i);
                 _context.Orders.Remove(order);
               _context.SaveChanges();   

          }

          }
          var pro=_context.Products.Where(p=>p.shop_id==shop_id).Select(p=>p.id);   //tim cac product of shop
          if(pro.ToList().Count>0)
          { foreach(var k in pro.ToList())                                      //xoa quan he trong bang mau of product
             { var productColor=_context.product_Colors.Where(p=>p.product_id==k).Select(p=>p.id);
                foreach(var n in productColor.ToList())
                 {var pc=new Product_Color();
                   pc=_context.product_Colors.FirstOrDefault(x=>x.id==n);
                 _context.product_Colors.Remove(pc);
                 _context.SaveChanges();


                 }
             
        var cmts=_context.Comments.Where(p=>p.product_id==k).Select(p=>p.id);
         if(cmts.ToList().Count>0)
          { foreach(var t in cmts.ToList())
           {
               var comment=new Comment();                                //xoa cac order 
                 comment=_context.Comments.FirstOrDefault(x=>x.id==t);
                 _context.Comments.Remove(comment);
               _context.SaveChanges();   
           }


          } 

           var product=new Product();                                 //xoa product
                 product=_context.Products.FirstOrDefault(x=>x.id==k);
                 _context.Products.Remove(product);
               _context.SaveChanges();      

             }
          }
            
            
         var check_paid=_context.Check_Paid_Shops.Where(p=>p.shop_id==shop_id).Select(p=>p.id);
          if(check_paid.ToList().Count>0)
          { foreach( var i in check_paid.ToList())
            { var c=new Check_paid_shop();
                 c=_context.Check_Paid_Shops.FirstOrDefault(x=>x.id==i);
                 _context.Check_Paid_Shops.Remove(c);
               _context.SaveChanges(); 

            }



          }   
            
            
          var shop=new Shop();                                            //xoa shop
          shop=_context.Shops.FirstOrDefault(x=>x.id==shop_id);
          _context.Shops.Remove(shop);
          _context.SaveChanges();
              
           }
          
          //delete cac order co lien quan
          
          var s1=_context.Orders.Where(p=>p.user_id==id).Select(p=>p.id); //tim cac order lien quan den user do
           if(s1.ToList().Count>0)
          { 
          foreach(var i in s1.ToList())
          { var o=_context.Order_details.Where(p=>p.order_id==i).Select(p=>p.id);//tim cac order detail of order do
              if (o.ToList().Count>0)                                           //xoa cac order detail
              {
               foreach(var j in o.ToList())
                 {var Order_detail=new Order_detail();
                 Order_detail=_context.Order_details.FirstOrDefault(x=>x.id==j);
                 _context.Order_details.Remove(Order_detail);
               _context.SaveChanges();
                 }
               
              }

                 var order=new Order();                                //xoa cac order 
                 order=_context.Orders.FirstOrDefault(x=>x.id==i);
                 _context.Orders.Remove(order);
               _context.SaveChanges();   

          }
          }
         //xoa comment
         var comments=_context.Comments.Where(p=>p.user_id==id).Select(p=>p.id);
         if(comments.ToList().Count>0)
          { foreach(var t in comments.ToList())
           {
               var comment=new Comment();                                //xoa cac order 
                 comment=_context.Comments.FirstOrDefault(x=>x.id==t);
                 _context.Comments.Remove(comment);
               _context.SaveChanges();   
           }


          }         
          
                                                                     //xoa
           var user=new User();
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

        public void UpdateUser( User user)
        {   var old_user=new User();
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
          var s=_context.Users.Select(p=>p).Where(s=>s.user_name.Contains(name));
           return s.ToList();
       }
       
    }
}