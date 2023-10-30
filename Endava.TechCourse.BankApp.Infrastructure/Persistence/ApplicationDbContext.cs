﻿using Microsoft.EntityFrameworkCore;
using Endava.TechCourse.BankApp.Domain.Models;
namespace Endava.TechCourse.BankApp.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
	public DbSet<Wallet> Wallets { get; set; }
	public DbSet<Currency> Currencies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Wallet>().HasKey(w => w.Id);
        modelBuilder.Entity<Currency>().HasKey(c => c.Id);
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
		
	}
}
