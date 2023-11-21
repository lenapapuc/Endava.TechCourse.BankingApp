﻿using Endava.TechCourse.BankApp.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Endava.University.BankApp.Infrastructure.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            var roles = Enum.GetNames(typeof(UserRole))
                .Select(role => new IdentityRole<Guid>() { Id = Guid.NewGuid(), Name = role, NormalizedName = role.Normalize() })
                .ToList();

            builder.HasData(roles);
        }
    }
}