using System.ComponentModel.DataAnnotations;

namespace LoadDwh.Data.Entites.Northwind
{
    public class DimProduct
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

    }
}
