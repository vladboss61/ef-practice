using ConsoleEFCore.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEFCore.Configurations
{
    public sealed class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder
                .ToTable("UserProfile")
                .HasKey(p => p.Id);

            builder.HasData(new UserProfile
            {
                Id = 88,
                About = "Some additional info",
                ImageUrl = "123",
                UserId = 77
            });
        }
    }
}
