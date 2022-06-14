using MVCPrinciples.Website.Data.Entities;

namespace MVCPrinciples.Website.Ropositories.Interfaces
{
	public interface IProductsRepository
	{
		IEnumerable<Product> GetCount(int count = 0);
		Product GetById(int id);
		void Update(Product product);
	}
}
