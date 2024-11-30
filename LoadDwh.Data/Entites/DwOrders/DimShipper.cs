using System.ComponentModel.DataAnnotations;

namespace LoadDwh.Data.Entites.DwOrders
{
    public class DimShipper
    {
        [Key]
        public int ShipperId { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }
    }
}
