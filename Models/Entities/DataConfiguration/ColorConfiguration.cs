using System;
using final_project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace final_project.Models.Entities.DataConfiguration
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasData(
                new Color{
                    id = "1",
                    name = "Đỏ"
                },
                new Color{
                    id = "2",
                    name = "Hồng"
                },
                new Color{
                    id = "3",
                    name = "Trắng"
                },
                new Color{
                    id = "4",
                    name = "Đen"
                }
            );
        }
    }
}