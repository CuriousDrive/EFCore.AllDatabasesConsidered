using Microsoft.EntityFrameworkCore;

namespace Northwind.Data
{
    public partial class ExtendedNorthwindContext : northwindContext
    {
        public virtual DbSet<CustOrderHistory> CustOrderHistories { get; set; } = null!;

        public ExtendedNorthwindContext()
        {
        }

        public ExtendedNorthwindContext(DbContextOptions<northwindContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("name=NorthwindDB", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustOrderHistory>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.ProductName);
                entity.Property(e => e.Total);
            });

        }
    }
}
