using Endava.TechCourse.BankApp.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Infrastructure.Configurations
{
    public class WalletTypeConfiguration : IEntityTypeConfiguration<WalletType>
    {
        public void Configure(EntityTypeBuilder<WalletType> builder)
        {
            var platinumType = new WalletType()
            {
                Name = "Platinum",
                Description = "The best type of card, has the smallest commission",
                Commission = 3
            };

            var goldType = new WalletType()
            {
                Name = "Gold",
                Description = "Second Best",
                Commission = 4
            };

            var silverType = new WalletType()
            {
                Name = "Silver",
                Description = "Third Best",
                Commission = 5
            };

            var bestType = new WalletType()
            {
                Name = "Basic",
                Description = "Fourth Best",
                Commission = 10
            };
            builder.HasData(platinumType, goldType, silverType, bestType);
        }
    }
}
