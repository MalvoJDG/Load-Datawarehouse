using System.ComponentModel.DataAnnotations;

namespace LoadDwh.Data.DwOrders;

public partial class FactSupportedCustomer
{
    [Key]
    public int SupportedCustomersId { get; set; }

    public int EmployeeId { get; set; }

    public int? TotalCustomers { get; set; }

    public string EmployeerName { get; set; }
}