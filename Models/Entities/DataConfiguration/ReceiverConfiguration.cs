using System;
using final_project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace final_project.Models.Entities.DataConfiguration
{
    public class ReceiverConfiguration : IEntityTypeConfiguration<Receiver>
    {
        public void Configure(EntityTypeBuilder<Receiver> builder)
        {
            builder.HasData(
                new Receiver{
                    id = "1",
                    address = "193 NLB",
                    email = "damhoangbuu@gmail.com",
                    fullname = "Đàm Văn Hoàng Bửu",
                    phone = "0898237228"
                },
                new Receiver{
                    id = "2",
                    address = "193 NLB",
                    email = "buithikieu@gmail.com",
                    fullname = "Bùi Thị Kiều",
                    phone = "0975191672"
                },
                new Receiver{
                    id = "3",
                    address = "193 NLB",
                    email = "tranthusuong@gmail.com",
                    fullname = "Trần Thu Sương",
                    phone = "0975197462"
                },
                new Receiver{
                    id = "4",
                    address = "193 NLB",
                    email = "nguyentruongson@gmail.com",
                    fullname = "Nguyễn Trường Sơn",
                    phone = "0988191672"
                },
                new Receiver{
                    id = "5",
                    address = "193 NLB",
                    email = "damhoangbuu@gmail.com",
                    fullname = "Đàm Văn Hoàng Bửu"
                },
                new Receiver{
                    id = "6",
                    address = "193 NLB",
                    email = "damhoangbuu@gmail.com",
                    fullname = "Đàm Văn Hoàng Bửu",
                    phone = "0898237228"
                },
                new Receiver{
                    id = "7",
                    address = "193 NLB",
                    email = "damhoangbuu@gmail.com",
                    fullname = "Đàm Văn Hoàng Bửu",
                    phone = "0898237228"
                },
                new Receiver{
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