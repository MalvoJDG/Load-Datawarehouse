using System.ComponentModel.DataAnnotations;

namespace LoadDwh.Data.Entites.Northwind
{
    public class Shipper
    {
        [Key]
        public int ShipperId { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }
        public string? Phone {  get; set; }
    }
}
