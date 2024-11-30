using LoadDwh.Data.Contexts;
using LoadDwh.Data.Interfaces.DwOrders;
using LoadDwh.WorkerService;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) => {

            services.AddDbContextPool<NorthwindContext>(option => option.UseSqlServer(hostContext.Configuration.GetConnectionString("Northwind")));
            services.AddDbContextPool<DbOrderContext>(option => option.UseSqlServer(hostContext.Configuration.GetConnectionString("DbOrders")));

            services.AddScoped<IDataServiceDwOrders, DataServiceDwOrders>();
            services.AddHostedService<Worker>();

        });
}