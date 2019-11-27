using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models.Entities;
using final_project;
namespace final_project.Services
{  
      public class ProductService : IProductService
    {  private DataContext _context;

        public ProductService(DataContext context)
      { _context=context;
      }
        public void AddProduct(Product product)
        {   _context.Products.Add(product);
         _context.SaveChanges();
            //throw new NotImplementedException();
        }

        public void DeleteProduct(string id)
        {  var product=new Product();
           product=_context.Products.FirstOrDefault(x=>x.id==id);
           _context.Products.Remove(product);
           _context.SaveChanges();
            //throw new NotImplementedException();
        }

        public Product GetProductById(string id)
        {   var product=new Product();
           product=_context.Products.FirstOrDefault(x=>x.id==id);
            return product;
            //throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {    var products =new List<Product>();
           products=_context.Products.ToList();
           // return new string[] { "value1", "value2" };
            return products;
           // throw new NotImplementedException();
        }

        public void UpdateProduct(string id, Product product)
        {  
             var old_product=new Product();
             old_product=_context.Products.FirstOrDefault(x=>x.id==id);
             old_product.product_name=product.product_name;
             old_product.description=product.description;
             old_product.cat_id=old_product.cat_id;
             old_product.price=old_product.price;
             old_product.quantity=old_product.quantity;
             old_product.shop_id=old_product.shop_id;
             _context.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}