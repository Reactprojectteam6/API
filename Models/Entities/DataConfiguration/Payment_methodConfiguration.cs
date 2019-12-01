using System;
using final_project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace final_project.Models.Entities.DataConfiguration
{
    public class Payment_methodConfiguration : IEntityTypeConfiguration<Payment_method>
    {
        public void Configure(EntityTypeBuilder<Payment_method> builder)
        {
            builder.HasData(
                new Payment_method{
                    id = "1",
                    name = "Thanh toán khi nhận hàng"
                },
                new Payment_method{
                    id = "2",
                    name = "Paypal"
                }
            );
        }
    }
}