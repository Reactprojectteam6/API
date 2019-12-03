using System;
using final_project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace final_project.Models.Entities.DataConfiguration
{
    public class Product_ColorConfiguration : IEntityTypeConfiguration<Product_Color>
    {
        public void Configure(EntityTypeBuilder<Product_Color> builder)
        {
            builder.HasData(
                new Product_Color{
                    id = "1",
                    product_id = "1",
                    color_id = "3"
                },
                new Product_Color{
                    id = "2",
                    product_id = "2",
                    color_id = "3"
                },
                new Product_Color{
                    id = "3",
                    product_id = "3",
                    color_id = "3"
                },
                new Product_Color{
                    id = "4",
                    product_id = "4",
                    color_id = "3"
                },
                new Product_Color{
                    id = "5",
                    product_id = "5",
                    color_id = "3"
                },
                new Product_Color{
                    id = "6",
                    product_id = "6",
                    color_id = "3"
                },
                new Product_Color{
                    id = "7",
                    product_id = "7",
                    color_id = "3"
                },
                new Product_Color{
                    id = "8",
                    product_id = "8",
                    color_id = "3"
                },
                new Product_Color{
                    id = "9",
                    product_id = "9",
                    color_id = "3"
                },
                new Product_Color{
                    id = "10",
                    product_id = "10",
                    color_id = "3"
                },
                new Product_Color{
                    id = "11",
                    product_id = "11",
                    color_id = "3"
                },
                new Product_Color{
                    id = "12",
                    product_id = "12",
                    color_id = "3"
                },
                new Product_Color{
                    id = "13",
                    product_id = "13",
                    color_id = "3"
                },
                new Product_Color{
                    id = "14",
                    product_id = "14",
                    color_id = "3"
                },
                new Product_Color{
                    id = "15",
                    product_id = "15",
                    color_id = "3"
                },
                new Product_Color{
                    id = "16",
                    product_id = "16",
                    color_id = "3"
                },
                new Product_Color{
                    id = "17",
                    product_id = "18",
                    color_id = "1"
                },
                new Product_Color{
                    id = "18",
                    product_id = "19",
                    color_id = "2"
                },
                new Product_Color{
                    id = "19",
                    product_id = "20",
                    color_id = "1"
                },
                new Product_Color{
                    id = "20",
                    product_id = "21",
                    color_id = "1"
                },
                new Product_Color{
                    id = "21",
                    product_id = "22",
                    color_id = "2"
                },
                new Product_Color{
                    id = "22",
                    product_id = "23",
                    color_id = "1"
                },
                new Product_Color{
                    id = "23",
                    product_id = "24",
                    color_id = "2"
                },
                new Product_Color{
                    id = "24",
                    product_id = "25",
                    color_id = "4"
                },
                new Product_Color{
                    id = "25",
                    product_id = "26",
                    color_id = "4"
                },
                new Product_Color{
                    id = "26",
                    product_id = "27",
                    color_id = "4"
                },
                new Product_Color{
                    id = "27",
                    product_id = "28",
                    color_id = "4"
                },  
                new Product_Color{
                    id = "28",
                    product_id = "29",
                    color_id = "4"
                },
                new Product_Color{
                    id = "29",
                    product_id = "30",
                    color_id = "4"
                },
                new Product_Color{
                    id = "30",
                    product_id = "37",
                    color_id = "3"
                },
                new Product_Color{
                    id = "31",
                    product_id = "38",
                    color_id = "3"
                },
                new Product_Color{
                    id = "32",
                    product_id = "39",
                    color_id = "3"
                },
                new Product_Color{
                    id = "33",
                    product_id = "40",
                    color_id = "3"
                },
                new Product_Color{
                    id = "34",
                    product_id = "41",
                    color_id = "3"
                },
                new Product_Color{
                    id = "35",
                    product_id = "42",
                    color_id = "3"
                },
                new Product_Color{
                    id = "36",
                    product_id = "43",
                    color_id = "1"
                },
                new Product_Color{
                    id = "37",
                    product_id = "44",
                    color_id = "1"
                },
                new Product_Color{
                    id = "38",
                    product_id = "45",
                    color_id = "2"
                },
                new Product_Color{
                    id = "39",
                    product_id = "46",
                    color_id = "2"
                },
                new Product_Color{
                    id = "40",
                    product_id = "47",
                    color_id = "2"
                },
                new Product_Color{
                    id = "41",
                    product_id = "48",
                    color_id = "1"
                },
                  new Product_Color{
                    id = "42",
                    product_id = "50",
                    color_id = "1"
                }
            );
        }
    }
}