using System;
using final_project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace final_project.Models.Entities.DataConfiguration
{
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.HasData(
                new Shop{
                    id = "1",
                    name = "Shop mỹ phẩm bà Kèo",
                    payment_account = "abcxyz",
                    user_id = "2",
                    address = "193 NLB",
                    email = "buithikieu@gmail.com"
                },
                new Shop{
                    id = "2",
                    name = "Ông Huân Vlog",
                    payment_account = "abcxyz",
                    user_id = "7",
                    address = "194 NLB",
                    email = "votuonghuan@gmail.com"
                },
                new Shop{
                    id = "3",
                    name = "Bé Sơn Parody",
                    payment_account = "abcxyz",
                    user_id = "8",
                    address = "195 NLB",
                    email = "nguyentruongson@gmail.com"
                }
            );
        }
    }
}