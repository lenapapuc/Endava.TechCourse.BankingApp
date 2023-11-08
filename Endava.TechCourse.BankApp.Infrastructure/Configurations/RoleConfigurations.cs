using Endava.TechCourse.BankApp.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Infrastructure.Configurations
{
    /// <summary>
    /// we can do this every time we want to initialize the database with some data, for example an admin user, don't forget 
    /// to add into the Application DbContext
    /// </summary>
    public class RoleConfigurations : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            var roles = Enum.GetNames(typeof(UserRole))
                    .Select(role => new IdentityRole<Guid>() { Id = Guid.NewGuid(), Name = role }).ToList();

            builder.HasData(roles);
        }
    }
}
