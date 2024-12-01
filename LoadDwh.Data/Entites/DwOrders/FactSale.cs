using System.ComponentModel.DataAnnotations;

namespace LoadDwh.Data.DwOrders;

public partial class FactSale
{
    [Key]
    public int OrderId { get; set; }

    public int EmployeeId { get; set; }

    public string CustomerId { get; set; }

    public int ShipperId { get; set; }

    public int ProductId { get; set; }

    public int DateId { get; set; }

    public decimal TotalSales { get; set; }

    public string Country { get; set; }

    public int QuantitySold { get; set; }
}