using System.ComponentModel.DataAnnotations;

namespace LoadDwh.Data.Entites.Northwind
{
    public class DimCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

    }
}
