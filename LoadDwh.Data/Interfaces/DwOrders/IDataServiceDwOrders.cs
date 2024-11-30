using LoadDwh.Data.Results;

namespace LoadDwh.Data.Interfaces.DwOrders
{
    public interface IDataServiceDwOrders
    {
        Task<OperationResults> LoadDw();

    }
}
