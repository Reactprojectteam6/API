using System;
using final_project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace final_project.Models.Entities.DataConfiguration
{
    public class WebsiteConfiguration : IEntityTypeConfiguration<Website>
    {
        public void Configure(EntityTypeBuilder<Website> builder)
        {
            builder.HasData(
                new Website{
                    id = "1",
                    address="Núi Thành,Quảng Nam",
                    email="buithikieu16tclc3@gmail",
                    phone="0372751805",
                    sandbox="AYYYpz6WNLv_ibeOkju_7uX2SM1NWRmTd3VrE-HEu7UuXEdvSvQ1vLGUS6upj9TIGV_Cv_wTfG8fZo6O",
                    production="AakS9m2vudatyxfs7xLTHAiA_oEgZ5h7lK8D6JlhTOUv24riXWap8bTK5fatuvlLVsnQ1TVX8Lm55zVr",
                }
            );
        }
    }
}