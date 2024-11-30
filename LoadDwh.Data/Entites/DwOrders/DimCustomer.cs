using System.ComponentModel.DataAnnotations;

namespace LoadDwh.Data.Entities.DwOrders
{
    public class DimCustomer
    {
        [Key]
        [StringLength(5)]
        public string CustomerID { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [StringLength(40)]
        public string ContactName { get; set; }

        [StringLength(15)]
        public string City { get; set; }

        [StringLength(15)]
        public string Region { get; set; }

        [StringLength(15)]
        public string Country { get; set; }

    }
}
