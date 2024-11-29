using LoadDwh.Data.Entites.DwSells;
using LoadDwh.Data.Entites.Northwind;
using Microsoft.EntityFrameworkCore;

namespace LoadDwh.Data.Contexts
{
    public class DbOrderContext : DbContext
    {
        public DbOrderContext(DbContextOptions<DbOrderContext> options) : base(options) { }

        #region DbSet
        public DbSet<DimCategory> DimCategories { get; set; }
        public DbSet<DimEmployee> DimEmployees { get; set; }
        public DbSet<DimProduct> DimProducts { get; set; }
        #endregion
    }
}
