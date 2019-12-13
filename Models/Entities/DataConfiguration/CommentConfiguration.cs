using System;
using final_project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace final_project.Models.Entities.DataConfiguration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData(
                new Comment{
                    id = "1",
                    contents = "Đồ cùi quá",
                    rate = 3,
                    product_id = "1",
                    user_id = "1"
                },
                new Comment{
                    id = "2",
                    contents = "Oke",
                    rate = 4,
                    product_id = "1",
                    user_id = "2"
                },
                new Comment{
                    id = "3",
                    contents = "Oke",
                    rate = 5,
                    product_id = "1",
                    user_id = "3"
                },
                new Comment{
                    id = "4",
                    contents = "Oke",
                    rate = 5,
                    product_id = "1",
                    user_id = "4"
                },
                new Comment{
                    id = "5",
                    contents = "Đồ cùi quá",
                    rate = 3,
                    product_id = "2",
                    user_id = "1"
                },
                new Comment{
                    id = "6",
                    contents = "Oke",
                    rate = 4,
                    product_id = "2",
                    user_id = "2"
                },
                new Comment{
                    id = "7",
                    contents = "Oke",
                    rate = 5,
                    product_id = "2",
                    user_id = "3"
                },
                new Comment{
                    id = "8",
                    contents = "Oke",
                    rate = 5,
                    product_id = "3",
                    user_id = "4"
                },
                 new Comment{
                    id = "9",
                    contents = "Oke",
                    rate = 1,
                    product_id = "4",
                    user_id = "4"
                },
                 new Comment{
                    id = "10",
                    contents = "Oke",
                    rate = 1,
                    product_id = "5",
                    user_id = "4"
                }
                ,
                 new Comment{
                    id = "11",
                    contents = "Oke",
                    rate = 1,
                    product_id = "6",
                    user_id = "4"
                }
                 ,
                 new Comment{
                    id = "12",
                    contents = "Oke",
                    rate = 1,
                    product_id = "7",
                    user_id = "4"
                } ,
                 new Comment{
                    id = "13",
                    contents = "Oke",
                    rate = 1,
                    product_id = "8",
                    user_id = "4"
                } ,
                 new Comment{
                    id = "14",
                    contents = "Oke",
                    rate = 1,
                    product_id = "9",
                    user_id = "4"
                } ,
                 new Comment{
                    id = "15",
                    contents = "Oke",
                    rate = 1,
                    product_id = "10",
                    user_id = "4"
                },
                 new Comment{
                    id = "16",
                    contents = "Oke",
                    rate = 1,
                    product_id = "11",
                    user_id = "4"
                }
            );
        }
    }
}