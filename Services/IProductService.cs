
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models.Entities;
namespace final_project.Services
{    public interface IProductService   {    
        public List<Product> GetProducts();
        public dynamic GetProductById(string id);
        public void AddProduct(dynamic product);
        public void UpdateProductShop(string id,Product product);
        public bool DeleteProduct(string id);
        
        public List<Product> GetProductsByName(string name);
        public string GetName(string id);
        
        public  List<Color> GetColors();
        public dynamic GetProductsOnShop(string shop_id);

        public dynamic GetProductDetailByID(string id);
        
        public void UpdatePermission(string id,Product product);
    }
}