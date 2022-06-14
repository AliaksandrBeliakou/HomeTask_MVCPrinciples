using Microsoft.EntityFrameworkCore;
using MVCPrinciples.Website.Data;
using MVCPrinciples.Website.Data.Entities;
using MVCPrinciples.Website.Ropositories.Interfaces;

namespace MVCPrinciples.Website.Ropositories
{
	public class ProductsRepository : IProductsRepository
	{
		private readonly NorthwindContext context;
		public ProductsRepository(NorthwindContext context)
		{
			this.context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public void Update(Product product)
		{
			if (product is null)
			{
				throw new ArgumentNullException(nameof(product));
			}

			var productEntity = context.Products.Find(product.ProductId);
			if (productEntity is null)
			{
				throw new DbUpdateException($"Product with id equal {product.ProductId} is not exist.");
			}

			productEntity.ProductName = product.ProductName;
			productEntity.CategoryID = product.CategoryID;
			productEntity.SupplierID = product.SupplierID;
			productEntity.QuantityPerUnit = product.QuantityPerUnit;
			productEntity.UnitPrice = product.UnitPrice;
			productEntity.UnitsInStock = product.UnitsInStock;
			productEntity.UnitsOnOrder = product.UnitsOnOrder;
			productEntity.ReorderLevel = product.ReorderLevel;
			productEntity.Discontinued = product.Discontinued;
			context.SaveChanges();
		}

		public Product GetById(int id)
		{
			if (id < 1)
			{
				throw new ArgumentOutOfRangeException(nameof(id));
			}

			return context.Products.Single(p => p.ProductId == id);
		}

		public IEnumerable<Product> GetCount(int count = 0)
		{
			IQueryable<Product> products = context.Products;
			if (count > 0)
			{
				products = products.Take(count);
			}

			return products.Include(p => p.Category).Include(p => p.Supplier);
		}
	}
}
