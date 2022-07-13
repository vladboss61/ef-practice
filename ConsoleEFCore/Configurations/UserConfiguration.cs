using ConsoleEFCore.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEFCore.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("User")
                .HasKey(p => p.Id);


            builder.HasData(new Company
            {
                Id = 10
            });

            builder.HasData(new User
            {
                Id = 10,
                CompanyId = 1,
                FirstName = "FirstName10",
                LastName = "FirstName10",
                HiredDate = DateTime.UtcNow,
                Profile = null
            });
        }
    }
}
