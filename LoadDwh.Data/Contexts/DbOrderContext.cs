using LoadDwh.Data.DwOrders;
using LoadDwh.Data.Entites.DwOrders;
using LoadDwh.Data.Entities.DwOrders;
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
        public DbSet<DimCustomer> DimCustomers { get; set; }
        public DbSet<DimShipper> DimShippers { get; set; }
        public DbSet<FactSale> FactSales { get; set; }
        public DbSet<FactSupportedCustomer> factSupportedCustomers { get; set; }
        #endregion
    }
}
