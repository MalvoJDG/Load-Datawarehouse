using Microsoft.EntityFrameworkCore;

namespace LoadDwh.Models.Models;

public partial class NorthwindContext : DbContext
{
    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TotalSuported> TotalSuporteds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}