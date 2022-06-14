using MVCPrinciples.Website.Data.Entities;

namespace MVCPrinciples.Website.Ropositories.Interfaces
{
	public interface ICategoriesRepository
	{
		IEnumerable<Category> GetAll();
	}
}
