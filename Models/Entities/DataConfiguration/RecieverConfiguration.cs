using System;
using final_project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace final_project.Models.Entities.DataConfiguration
{
    public class RecieverConfiguration : IEntityTypeConfiguration<Reciever>
    {
        public void Configure(EntityTypeBuilder<Reciever> builder)
        {
            builder.HasData(
                new Reciever{
                    id = "1",
                    address = "193 NLB",
                    email = "damhoangbuu@gmail.com",
                    fullname = "Đàm Văn Hoàng Bửu",
                    phone = "0898237228"
                },
                new Reciever{
                    id = "2",
                    address = "193 NLB",
                    email = "buithikieu@gmail.com",
                    fullname = "Bùi Thị Kiều",
                    phone = "0975191672"
                },
                new Reciever{
                    id = "3",
                    address = "193 NLB",
                    email = "tranthusuong@gmail.com",
                    fullname = "Trần Thu Sương",
                    phone = "0975197462"
                },
                new Reciever{
                    id = "4",
                    address = "193 NLB",
                    email = "nguyentruongson@gmail.com",
                    fullname = "Nguyễn Trường Sơn",
                    phone = "0988191672"
                },
                new Reciever{
                    id = "5",
                    address = "193 NLB",
                    email = "damhoangbuu@gmail.com",
                    fullname = "Đàm Văn Hoàng Bửu"
                },
                new Reciever{
                    id = "6",
                    address = "193 NLB",
                    email = "damhoangbuu@gmail.com",
                    fullname = "Đàm Văn Hoàng Bửu",
                    phone = "0898237228"
                },
                new Reciever{
                    id = "7",
                    address = "193 NLB",
                    email = "damhoangbuu@gmail.com",
                    fullname = "Đàm Văn Hoàng Bửu",
                    phone = "0898237228"
                },
                new Reciever{
                    id = "8",
                    address = "193 NLB",
                    email = "damhoangbuu@gmail.com",
                    fullname = "Đàm Văn Hoàng Bửu",
                    phone = "0898237228"
                }
            );
        }
    }
}