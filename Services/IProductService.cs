
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models.Entities;
namespace final_project.Services
{    public interface IProductService   {    
        public dynamic GetProducts();
        public dynamic GetProductById(string id);
        public void AddProduct(dynamic product);
        public void UpdateProductShop(string id,Product product);
        public bool DeleteProduct(string id);
        
      //  public List<Product> GetProductsByName(string name);
        public string GetName(string id);
        
        public  List<Color> GetColors();
        public dynamic GetProductsOnShop(string shop_id);

        public dynamic GetProductDetailByID(string id);
        
        public void UpdatePermission(string id,Product product);
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(string id);
        
        public List<Product> GetProductsByName(string name);
        public  List<Color> GetColors(string name);
        public int GetRating(string id);
        public dynamic GetProductByNameAndColor(string name,string color,string shop_id);
        public List<Product> GetProductByRating(int a,int b);
        public List<Product> GetHotProduct();
    }
}