using Microsoft.EntityFrameworkCore;
using Northwind.Models;

namespace Northwind.Data;

public class NorthwindContext : DbContext
{
    
    public DbSet<Employee>? Employees { get; set; }
    public DbSet<Customer>? Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos(
            "https://northwind-db.documents.azure.com:443/", 
            "bZHUM10nKDHikw1QRWEz8ZF4gtzH4As4EKKcAd34MUhJxAYxDkynQCpoiG6jsa7m7kNsGrNgpdFJwkFJiFqRvQ==", 
            "northwind-db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // configuring Employees
        modelBuilder.Entity<Employee>()
            .UseETagConcurrency()
            .ToContainer("Employees") // ToContainer
            .HasPartitionKey(e => e.Id); // Partition Key

        // configuring Customers
        modelBuilder.Entity<Customer>()
            .UseETagConcurrency()
            .ToContainer("Customers") // ToContainer
            .HasPartitionKey(c => c.Id); // Partition Key

        modelBuilder.Entity<Customer>().OwnsMany(p => p.Orders);
    }

}