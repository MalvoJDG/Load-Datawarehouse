using System.ComponentModel.DataAnnotations;

namespace LoadDwh.Data.Entites.DwOrders
{
    public class DimProduct
    {
        [Key]
        public int ProductID { get; set; }
        public int ProductKey{ get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

    }
}
