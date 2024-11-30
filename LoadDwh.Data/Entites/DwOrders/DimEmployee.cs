using System.ComponentModel.DataAnnotations;

namespace LoadDwh.Data.Entites.DwOrders
{
    public class DimEmployee
    {
        [Key] 
        public int EmployeeId { get; set; }

        public string? Name { get; set; }
        public int EmployeeKey { get; set; }
    }
}
