using LoadDwh.Data.Entites.Northwind;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;


namespace LoadDwh.Data.Contexts
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
        { }

        #region DbSet
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        #endregion
     
    }
}
