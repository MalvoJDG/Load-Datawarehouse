using LoadDwh.Data.Entites.Northwind;
using LoadDwh.Data.Entities.Northwind;
using LoadDwh.Data.Models;
using LoadDwh.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;


namespace LoadDwh.Data.Contexts
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
        { 
            
        }

        #region DbSet
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<SalesSummary> SalesSummaries { get; set; }
        public DbSet<TotalSuported> TotalSuporteds { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesSummary>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("SalesSummary", "DWH");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.CustomerId)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength()
                    .HasColumnName("CustomerID");
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(31);
                entity.Property(e => e.ShipperId).HasColumnName("ShipperID");
                entity.Property(e => e.ShipperName)
                    .IsRequired()
                    .HasMaxLength(40);

                modelBuilder.Entity<TotalSuported>(entity =>
                {
                    entity
                        .HasNoKey()
                        .ToView("TotalSuported", "DWH");

                    entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
                    entity.Property(e => e.NombreEmpleado)
                        .IsRequired()
                        .HasMaxLength(31);
                });

            });
        }

    }
}
