using MVCPrinciples.Website.Models;

namespace MVCPrinciples.Website.Services
{
	public interface IProductsService
	{
		IEnumerable<ProductVM> GetProducts();
		ProductEditVM GetProductById(int id);
		void Update(ProductEditVM product);
	}
}
