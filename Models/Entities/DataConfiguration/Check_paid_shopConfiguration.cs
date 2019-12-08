using System;
using final_project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace final_project.Models.Entities.DataConfiguration
{
    public class Check_paid_shopConfiguration : IEntityTypeConfiguration<Check_paid_shop>
    {
        public void Configure(EntityTypeBuilder<Check_paid_shop> builder)
        {
            builder.HasData(
                new Check_paid_shop{
                    id = "1",
                    date_paid = DateTime.Now,
                    date_expired = DateTime.Now,
                    money = 200000,
                    shop_id = "1"
                },
                new Check_paid_shop{
                    id = "2",
                    date_paid =DateTime.Now,
                    date_expired = DateTime.Now,
                    money = 200000,
                    shop_id = "2"
                },
                new Check_paid_shop{
                    
                    id = "3",
                    date_paid = DateTime.Now,
                    date_expired = DateTime.Now,
                    money = 200000,
                    shop_id = "3"
                }
            );
        }
    }
}