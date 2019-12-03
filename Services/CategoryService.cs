using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project;
using final_project.Models.Entities;
using final_project.Services;

namespace final_project.Services
{
    public class CategoryService : ICategoryService
    {  private DataContext _context;

     public   CategoryService(DataContext dataContext)
     {
         _context=dataContext;
     }
        public void AddCategory(Category category)
        {  _context.Categories.Add(category);
           _context.SaveChanges();
            //throw new NotImplementedException();
        }

        public void DeleteCategory(string  id)
        {  var category=new Category();
           category=_context.Categories.FirstOrDefault(x=>x.id==id);
           _context.Categories.Remove(category);
           _context.SaveChanges();
            //throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {  var categories=new List<Category>();
            categories=_context.Categories.ToList();
             return categories;
            //throw new NotImplementedException();
        }

        public Category GetCategoryById(string  id)
        {   var category=new Category();
         category=_context.Categories.FirstOrDefault(x=>x.id==id);
         return category;
        //throw new NotImplementedException();
        }

        public void UpdateCategory(string id, Category category)
        {   var old_category=_context.Categories.FirstOrDefault(x=>x.id==id);
           old_category.name=category.name;
           old_category.parent_id=category.parent_id;
           _context.SaveChanges();
            //throw new NotImplementedException();
        }
         public List <Category> GetSubCategory()
         { var list=new List<Category>();
           var s=from p in _context.Categories where (p.parent_id!=p.id) select p;
           list=s.ToList();
          return list;
          
         } 
         public List<Category> GetCategory()
         {  
             var list=new List<Category>();
             var s=from p in _context.Categories where p.parent_id==p.id select p;
               list=s.ToList();
               return list;

         }
          public List<Product> GetProductByCategory(string  id)
          {  
            List<Product> list=new List<Product>();
            List<Category> listsub= new List<Category>();
            var s=from p in _context.Products where (p.cat_id==id) select p;
            if(s.ToList().Count>=1) list=s.ToList();
            else
            {  
          
               var l=from p in _context.Categories where (p.parent_id==id) select p;
              foreach(var lists in l.ToList())
              {
                  var s1=from p in _context.Products where (p.cat_id==lists.id) select p;
                  foreach(var product in s1.ToList())
                  list.Add(product);
              }
                  
               
            }
            
            return list;
         



          }

    
          }
    }        
