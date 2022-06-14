using MVCPrinciples.Website.Models;

namespace MVCPrinciples.Website.Services
{
	public interface ICategoriesService
	{
		IEnumerable<CategoryVM> GetCategories();
	}
}
