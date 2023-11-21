﻿
using Endava.TechCourse.BankApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Endava.University.BankApp.Infrastructure.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            var defaultCurrency = new Currency()
            {
                Name = "Leu Moldovenesc",
                CurrencyCode = "MDL",
                ChangeRate = 1
            };

            builder.HasData(defaultCurrency);
        }
    }
}