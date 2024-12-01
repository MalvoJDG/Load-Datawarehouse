namespace LoadDwh.Data.Models;

public class SalesSummary
{
    public string CustomerId { get; set; }

    public string CompanyName { get; set; }

    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; }
    public string Country { get; set; }

    public int ShipperId { get; set; }
    public int ProductId { get; set; }

    public string ShipperName { get; set; }

    public int DateKey { get; set; }

    public int Año { get; set; }

    public int Mes { get; set; }

    public double TotalVentas { get; set; }

    public int Cantidad { get; set; }
}