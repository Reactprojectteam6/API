using System;
using final_project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace final_project.Models.Entities.DataConfiguration
{
    public class Order_detailConfiguration : IEntityTypeConfiguration<Order_detail>
    {
        public void Configure(EntityTypeBuilder<Order_detail> builder)
        {
            builder.HasData(
                new Order_detail{
                    id = "1",
                    price = 900000,
                    product_id = "1",
                    quantity = 1,
                    order_id = "1"
                },
                new Order_detail{
                    id = "2",
                    price = 800000,
                    product_id = "2",
                    quantity = 1,
                    order_id = "2"
                },
                new Order_detail{
                    id = "3",
                    price = 1000000,
                    product_id = "3",
                    quantity = 1,
                    order_id = "3"
                }
            );
        }
    }
}