using MVCPrinciples.Website.Models;
using MVCPrinciples.Website.Ropositories.Interfaces;

namespace MVCPrinciples.Website.Services
{
	public class ProductsService : IProductsService
	{
		private readonly IProductsRepository productsRepository;
		private readonly int productOnPageAmount;

		public ProductsService(IProductsRepository productsRepository, IConfiguration configuratrion)
		{
			this.productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
			this.productOnPageAmount = configuratrion?.GetValue<int>("ProductsOnPageAmount") ?? throw new ArgumentNullException(nameof(configuratrion));
		}

		public ProductEditVM GetProductById(int id)
		{
			if (id < 1)
			{
				throw new ArgumentOutOfRangeException(nameof(id));
			}
			var product = productsRepository.GetById(id);
			var productVM = new ProductEditVM
			{
				ProductId = product.ProductId,
				ProductName = product.ProductName,
				CategoryID = product.CategoryID,
				SupplierID = product.SupplierID,
				QuantityPerUnit = product.QuantityPerUnit,
				UnitPrice = product.UnitPrice,
				UnitsInStock = product.UnitsInStock,
				UnitsOnOrder = product.UnitsOnOrder,
				ReorderLevel = product.ReorderLevel,
				Discontinued = product.Discontinued,
			};
			return productVM;
		}

		public IEnumerable<ProductVM> GetProducts()
		{
			return productsRepository.GetCount(productOnPageAmount).Select(p => new ProductVM
			{
				Id = p.ProductId,
				Name = p.ProductName,
				Category = p.Category.CategoryName,
				Supplier = p.Supplier.CompanyName,
				QuantityPerUnit = p.QuantityPerUnit,
				UnitPrice = p.UnitPrice,
				UnitsInStock = p.UnitsInStock,
				UnitsOnOrder = p.UnitsOnOrder,
				ReorderLevel = p.ReorderLevel,
				Discontinued = p.Discontinued,
			});
		}

		public void Update(ProductEditVM product)
		{
			if (product is null)
			{
				throw new ArgumentNullException(nameof(product));
			}

			productsRepository.Update(new Data.Entities.Product
			{
				ProductId = product.ProductId,
				ProductName = product.ProductName,
				CategoryID = product.CategoryID,
				SupplierID = product.SupplierID,
				QuantityPerUnit = product.QuantityPerUnit,
				UnitPrice = product.UnitPrice,
				UnitsInStock = product.UnitsInStock,
				UnitsOnOrder = product.UnitsOnOrder,
				ReorderLevel = product.ReorderLevel,
				Discontinued = product.Discontinued,
			});
		}
	}
}
