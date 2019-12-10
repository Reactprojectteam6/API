using System;
using final_project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace final_project.Models.Entities.DataConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                new Order{
                    id = "1",
                    date_create =new DateTime(1998,1,1),
                    date_paid = new DateTime(1998,1,1),
                    status = 1,
                    total = 900000,
                    payment_id = "1",
                    receiver_id = "1",
                    user_id = "1",
                    shop_id="1"
                },
                new Order{
                    id = "2",
                    date_create = new DateTime(1998,1,1),
                    date_paid = new DateTime(1998,1,1),
                    status = 2,
                    total = 800000,
                    payment_id = "1",
                    receiver_id = "3",
                    user_id = "3",
                    shop_id="1"
                },
                new Order{
                    id = "3",
                    date_create = new DateTime(1998,1,1),
                    date_paid = new DateTime(1998,1,1),
                    status = 3,
                    total = 1000000,
                    payment_id = "1",
                    receiver_id = "4",
                    user_id = "4",
                    shop_id="1"
                }
            );
        }
    }
}