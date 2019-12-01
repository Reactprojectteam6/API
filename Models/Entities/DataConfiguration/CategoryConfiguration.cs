using System;
using final_project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace final_project.Models.Entities.DataConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category{
                    id = "1",
                    name = "Chăm sóc da",
                    parent_id="1"
                }
                ,
                new Category{
                    id = "2",
                    name = "Trang điểm",
                    parent_id="2"
                },
                new Category{
                    id = "3",
                    name = "Chống nắng",
                    parent_id = "1"
                },
                new Category{
                    id = "4",
                    name = "Dưỡng ẩm",
                    parent_id = "1"
                },
                new Category{
                    id = "5",
                    name = "Mặt nạ",
                    parent_id = "1"
                },
                new Category{
                    id = "6",
                    name = "Nước hoa hồng",
                    parent_id = "1"
                },new Category{
                    id = "7",
                    name = "Tinh chất dưỡng",
                    parent_id = "1"
                },
                new Category{
                    id = "8",
                    name = "Chăm sóc môi",
                    parent_id = "2"
                },
                new Category{
                    id = "9",
                    name = "Kem nền",
                    parent_id = "2"
                },
                new Category{
                    id = "10",
                    name = "Mascara",
                    parent_id = "2"
                },
                new Category{
                    id = "11",
                    name = "Phấn phủ",
                    parent_id = "2"
                },
                new Category{
                    id = "12",
                    name = "Son",
                    parent_id = "2"
                }

            );
        }
    }
}