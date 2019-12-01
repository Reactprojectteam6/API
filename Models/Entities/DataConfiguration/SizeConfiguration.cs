using System;
using final_project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace final_project.Models.Entities.DataConfiguration
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasData(
                new Size{
                    id = "1",
                    name = "250 ml"
                },
                new Size{
                    id = "2",
                    name = "500 ml"
                }
            );
        }
    }
}