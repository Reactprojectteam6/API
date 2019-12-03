
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models.Entities;
namespace final_project.Services
{    public interface IProductService   {    
        public List<Product> GetProducts();
        public dynamic GetProductById(string id);
        public void AddProduct(Product product);
        public void UpdateProduct(string id,Product product);
        public void DeleteProduct(string id);
        
        public List<Product> GetProductsByName(string name);
        public string GetName(string id);
        
         public  List<Color> GetColors();
      


    }
}