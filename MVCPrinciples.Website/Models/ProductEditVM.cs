using System.ComponentModel.DataAnnotations;

namespace MVCPrinciples.Website.Models
{
    public class ProductEditVM
    {
		[Required]
		public int ProductId { get; set; }
        [Required]
        [MaxLength(40)]
		public string ProductName { get; set; }
		public int SupplierID { get; set; }
		public int CategoryID { get; set; }
		[MaxLength(40)]
		public string? QuantityPerUnit { get; set; }
        [Range(0, 1000000)]
		public decimal? UnitPrice { get; set; }
		public Int16? UnitsInStock { get; set; }
		[Range(0, 1000)]
		public Int16? UnitsOnOrder { get; set; }
		public Int16? ReorderLevel { get; set; }
        [Required]
		public bool Discontinued { get; set; }
	}
}
