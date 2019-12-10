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
                    shop_name = "Shop mỹ phẩm bà Kèo",
                    payment_account = "abcxyz",
                    user_id = "2",
                    address = "193 NLB",
                    email = "buithikieu@gmail.com",
                    sandbox="AflZ3L1sfI6M45m8x1OvqF-cLAPO2uWwfQTkTiwqdNrgS-RTQhjuAYqXJYOHDHxW82G_lPur_gGkz2eC",
                    production="AakS9m2vudatyxfs7xLTHAiA_oEgZ5h7lK8D6JlhTOUv24riXWap8bTK5fatuvlLVsnQ1TVX8Lm55zVr",
                },
                new Shop{
                    id = "2",
                    shop_name = "Ông Huân Vlog",
                    payment_account = "abcxyz",
                    user_id = "7",
                    address = "194 NLB",
                    email = "votuonghuan@gmail.com",
                    sandbox="AaWOS3eowQdRfXGojWXfp15QEgw4ylIUYw5iittDOOde9XYNAsrwjYW9236KebkAF_FeKR30t4fCjp7w",
                    production="AakS9m2vudatyxfs7xLTHAiA_oEgZ5h7lK8D6JlhTOUv24riXWap8bTK5fatuvlLVsnQ1TVX8Lm55zVr",

                },
                new Shop{
                    id = "3",
                    shop_name = "Bé Sơn Parody",
                    payment_account = "abcxyz",
                    user_id = "8",
                    address = "195 NLB",
                    email = "nguyentruongson@gmail.com",
                    sandbox="AQk3ajkq4FqLtnXsIliLZ1NZzAHKWJzR70yMQdTfTg_8EbfBrmCJ44Bby1_cVkzFpwsEibf8uu3xGuSS",
                    production="AakS9m2vudatyxfs7xLTHAiA_oEgZ5h7lK8D6JlhTOUv24riXWap8bTK5fatuvlLVsnQ1TVX8Lm55zVr",
                }
            );
        }
    }
}