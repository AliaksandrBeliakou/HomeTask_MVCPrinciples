namespace MVCPrinciples.Website.Models
{
    public class ProductVM
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Supplier { get; set; }
		public string Category { get; set; }
		public string? QuantityPerUnit { get; set; }
		public decimal? UnitPrice { get; set; }
		public Int16? UnitsInStock { get; set; }
		public Int16? UnitsOnOrder { get; set; }
		public Int16? ReorderLevel { get; set; }
		public bool Discontinued { get; set; }
	}
}
