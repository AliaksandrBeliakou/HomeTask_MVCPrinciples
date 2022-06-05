namespace MVCPrinciples.Website.Data.Entities
{
    public class Product
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int SupplierID { get; set; }
		public int CategoryID { get; set; }
		public string? QuantityPerUnit { get; set; }
		public decimal? UnitPrice { get; set; }
		public Int16? UnitsInStock { get; set; }
		public Int16? UnitsOnOrder { get; set; }
		public Int16? ReorderLevel { get; set; }
		public bool Discontinued { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
	}
}