using System;
using final_project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace final_project.Models.Entities.DataConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User{
                    id = "1",
                    user_name = "Đàm Văn Hoàng Bửu",
                    password = "123456",
                    email = "damhoangbuu@gmail.com",
                    phone = "0898237228",
                    role = 1,
                    address = "193 NLB",
                    permission=true,
                },
                new User{
                    id = "2",
                    user_name = "Bùi Thị Kiều",
                    password = "123456",
                    email = "buithikieu@gmail.com",
                    phone = "0898237228",
                    role = 2,
                    address = "193 NLB",
                    permission=true
                },
                new User{
                    id = "3",
                    user_name = "Trần Thu Sương",
                    password = "123456",
                    email = "tranthusuong@gmail.com",
                    phone = "0898237228",
                    role = 3,
                    address = "193 NLB",
                    permission=true
                },
                new User{
                    id = "4",
                    user_name = "Trần Phú Quy",
                    password = "123456",
                    email = "tranphuquy@gmail.com",
                    phone = "0898237228",
                    role = 3,
                    address = "193 NLB",
                    permission=true
                },
                    new User{
                    id = "5",
                    user_name = "Trần Chí Vĩ",
                    password = "123456",
                    email = "tranchivi@gmail.com",
                    phone = "0898237228",
                    role = 3,
                    address = "193 NLB",
                    permission=true
                },
                    new User{
                    id = "6",
                    user_name = "Trần Thị Anh Thư",
                    password = "123456",
                    email = "trananhthu@gmail.com",
                    phone = "0898237228",
                    role = 3,
                    address = "193 NLB",
                    permission=true
                },
                    new User{
                    id = "7",
                    user_name = "Võ Tường Huân",
                    password = "123456",
                    email = "votuonghuan@gmail.com",
                    phone = "0898237228",
                    role = 2,
                    address = "193 NLB",
                    permission=true
                },
                    new User{
                    id = "8",
                    user_name = "Nguyễn Trường Sơn",
                    password = "123456",
                    email = "nguyentruongson@gmail.com",
                    phone = "0898237228",
                    role = 2,
                    address = "193 NLB",
                    permission=true
                }        
            );
        }
    }
}