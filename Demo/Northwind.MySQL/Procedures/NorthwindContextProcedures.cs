using Microsoft.EntityFrameworkCore;

namespace Northwind.Data
{
    public partial class NorthwindContextProcedures : DbContext
    {
        public virtual DbSet<CustOrderHistory> CustOrderHistories { get; set; } = null!;

        public NorthwindContextProcedures(){}

        public NorthwindContextProcedures(DbContextOptions<NorthwindContextProcedures> options)
            : base(options) { }

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
