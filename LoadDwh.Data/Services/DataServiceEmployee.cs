using LoadDwh.Data.Contexts;
using LoadDwh.Data.Entites.DwSells;
using LoadDwh.Data.Entites.Northwind;
using LoadDwh.Data.Results;

namespace LoadDwh.Data.Interfaces.DwOrders
{
    public class DataServiceEmployee : IDataServiceEmployee
    {
        private readonly NorthwindContext _northwind;
        private readonly DbOrderContext _dbOderContext;
        public DataServiceEmployee(DbOrderContext dbOrderContext, NorthwindContext northwind)
        {
            _dbOderContext = dbOrderContext;
            _northwind = northwind;
        }


        public async Task<OperationResults> LoadDimCategory()
        {
            OperationResults result = new OperationResults();

            try
            {
                //Obtener empleadoso de la base de datos de northwind
                var categories = _northwind.Categories.Select(cat => new DimCategory()
                {
                    CategoryName = cat.CategoryName
                }).ToList();

                //Cargar los datos a la tabla de Dimension de producto
                await _dbOderContext.DimCategories.AddRangeAsync(categories);
                await _dbOderContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has ocurred loading DimCategory.{ex.Message}";
            }

            return result;
        }

        public async Task<OperationResults> LoadDimEmployee()
        {
            OperationResults result = new OperationResults();

            try
            {
                //Obtener empleadoso de la base de datos de northwind
                var employees = _northwind.Employees.Select(emp => new DimEmployee()
                {
                    Name = string.Concat(emp.FirstName, "", emp.LastName)
                }).ToList();

                //Cargar los empleados en la tabla de Dimension
                await _dbOderContext.DimEmployees.AddRangeAsync(employees);
                await _dbOderContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has ocurred loading DimEmployees.{ex.Message}";
            }

            return result;
        }

        public async Task<OperationResults> LoadDimProducts()
        {
            OperationResults result = new OperationResults();

            try
            {
                //Obtener productos de la base de datos de northwind
                var product = _dbOderContext.DimProducts.Select(prod => new DimProduct()
                {
                    ProductName = prod.ProductName
                }).ToList();

                await _dbOderContext.DimProducts.AddRangeAsync(product);
                await _dbOderContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has ocurred loading DimProduct.{ex.Message}";
            }

            return result;
        }
    }
}
