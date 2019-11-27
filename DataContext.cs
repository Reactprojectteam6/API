using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using final_project.Models.Entities;

namespace final_project
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Reciever> Recievers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Payment_method> Payment_methods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_detail> Order_details { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}