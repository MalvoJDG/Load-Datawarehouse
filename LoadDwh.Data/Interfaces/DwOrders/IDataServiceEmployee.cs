using LoadDwh.Data.Contexts;
using LoadDwh.Data.Entites.DwSells;
using LoadDwh.Data.Entites.Northwind;
using LoadDwh.Data.Results;

namespace LoadDwh.Data.Interfaces.DwOrders
{
    public interface IDataServiceEmployee
    {
        Task<OperationResults> LoadDimEmployee();
        Task<OperationResults> LoadDimProducts();
        Task<OperationResults> LoadDimCategory();

    }
}
