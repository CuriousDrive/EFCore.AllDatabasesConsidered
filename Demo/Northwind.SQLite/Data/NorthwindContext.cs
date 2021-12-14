using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Northwind.Models;

namespace Northwind.Data
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
        }

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeTerritory> EmployeeTerritories { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductDetail> ProductDetails { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<Shipper> Shippers { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<Territory> Territories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CategoryName).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.Description).HasColumnType("VARCHAR(8000)");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.Address).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.City).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.CompanyName).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.ContactName).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.ContactTitle).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.Country).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.Fax).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.Phone).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.PostalCode).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.Region).HasColumnType("VARCHAR(8000)");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.BirthDate).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.City).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.Country).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.Extension).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.FirstName).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.HireDate).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.HomePhone).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.LastName).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.Notes).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.PhotoPath).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.PostalCode).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.Region).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.Title).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.TitleOfCourtesy).HasColumnType("VARCHAR(8000)");
            });

            modelBuilder.Entity<EmployeeTerritory>(entity =>
            {
                entity.ToTable("EmployeeTerritory");

                entity.Property(e => e.Id).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.TerritoryId).HasColumnType("VARCHAR(8000)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeTerritories)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.Territory)
                    .WithMany(p => p.EmployeeTerritories)
                    .HasForeignKey(d => d.TerritoryId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.Freight).HasColumnType("DECIMAL");

                entity.Property(e => e.OrderDate).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.RequiredDate).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.ShipAddress).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.ShipCity).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.ShipCountry).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.ShipName).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.ShipPostalCode).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.ShipRegion).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.ShippedDate).HasColumnType("VARCHAR(8000)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.Id).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.Discount).HasColumnType("DOUBLE");

                entity.Property(e => e.UnitPrice).HasColumnType("DECIMAL");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ProductName).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.QuantityPerUnit).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.UnitPrice).HasColumnType("DECIMAL");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId);
            });

            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProductDetails");

                entity.Property(e => e.CategoryDescription).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.CategoryName).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.ProductName).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.QuantityPerUnit).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.SupplierName).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.SupplierRegion).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.UnitPrice).HasColumnType("DECIMAL");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RegionDescription).HasColumnType("VARCHAR(8000)");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.ToTable("Shipper");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CompanyName).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.Phone).HasColumnType("VARCHAR(8000)");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.City).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.CompanyName).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.ContactName).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.ContactTitle).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.Country).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.Fax).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.HomePage).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.Phone).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.PostalCode).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.Region).HasColumnType("VARCHAR(8000)");
            });

            modelBuilder.Entity<Territory>(entity =>
            {
                entity.ToTable("Territory");

                entity.Property(e => e.Id).HasColumnType("VARCHAR(8000)");

                entity.Property(e => e.TerritoryDescription).HasColumnType("VARCHAR(8000)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
