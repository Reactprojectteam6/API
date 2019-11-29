
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models.Entities;
namespace final_project.Services
{    public interface ICategoryService   {    
        public List<Category> GetCategories();
        public Category GetCategoryById(string id);
        public void AddCategory(Category category);
        public void UpdateCategory(string id,Category category);
        public void DeleteCategory(string id);
        public List <Category> GetSubCategory(string id); 
        public List<Category> GetCategory();

    }
}