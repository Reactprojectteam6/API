using System;
using final_project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace final_project.Models.Entities.DataConfiguration
{
    public class Product_SizeConfiguration : IEntityTypeConfiguration<Product_Size>
    {
        public void Configure(EntityTypeBuilder<Product_Size> builder)
        {
            builder.HasData(
                new Product_Size{
                    id = "1",
                    product_id = "1",
                    size_id = "1", 
                },
                new Product_Size{
                    id = "2",
                    product_id = "1",
                    size_id = "2", 
                },
                new Product_Size{
                    id = "3",
                    product_id = "2",
                    size_id = "1", 
                },
                new Product_Size{
                    id = "4",
                    product_id = "2",
                    size_id = "2", 
                },
                new Product_Size{
                    id = "5",
                    product_id = "3",
                    size_id = "1", 
                },
                new Product_Size{
                    id = "6",
                    product_id = "3",
                    size_id = "2", 
                },
                new Product_Size{
                    id = "7",
                    product_id = "4",
                    size_id = "1", 
                },
                new Product_Size{
                    id = "8",
                    product_id = "5",
                    size_id = "1", 
                },
                new Product_Size{
                    id = "9",
                    product_id = "6",
                    size_id = "1", 
                },
                new Product_Size{
                    id = "10",
                    product_id = "7",
                    size_id = "1", 
                },
                new Product_Size{
                    id = "11",
                    product_id = "8",
                    size_id = "1", 
                },
                new Product_Size{
                    id = "12",
                    product_id = "9",
                    size_id = "1", 
                },
                new Product_Size{
                    id = "13",
                    product_id = "10",
                    size_id = "1", 
                },
                new Product_Size{
                    id = "14",
                    product_id = "11",
                    size_id = "1", 
                },
                new Product_Size{
                    id = "15",
                    product_id = "6",
                    size_id = "1", 
                },
                new Product_Size{
                    id = "16",
                    product_id = "25",
                    size_id = "2", 
                },
                new Product_Size{
                    id = "17",
                    product_id = "26",
                    size_id = "2", 
                },
                new Product_Size{
                    id = "18",
                    product_id = "27",
                    size_id = "2", 
                },
                new Product_Size{
                    id = "19",
                    product_id = "28",
                    size_id = "2", 
                },
                new Product_Size{
                    id = "20",
                    product_id = "29",
                    size_id = "2", 
                },
                new Product_Size{
                    id = "21",
                    product_id = "30",
                    size_id = "2", 
                }

            );
        }
    }
}