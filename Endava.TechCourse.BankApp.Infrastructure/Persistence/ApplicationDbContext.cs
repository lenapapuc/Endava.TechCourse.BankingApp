using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Currency> Currencies { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Wallet>()
            .HasKey(e => e.Id);

        builder.Entity<Currency>()
            .HasKey(e => e.Id);

        builder.Entity<Currency>()
            .HasMany(e => e.Wallets)
            .WithOne(e => e.Currency)
            .HasForeignKey(e => e.CurrencyId)
            .IsRequired();

        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new RoleConfigurations());
    }
}