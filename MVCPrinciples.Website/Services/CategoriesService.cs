using MVCPrinciples.Website.Models;
using MVCPrinciples.Website.Ropositories.Interfaces;

namespace MVCPrinciples.Website.Services
{
	public class CategoriesService : ICategoriesService
	{
		private readonly ICategoriesRepository categoriesRepository;
		private readonly Base64Converter base64Converter;

		public CategoriesService(ICategoriesRepository categoriesRepository, Base64Converter base64Converter)
		{
			this.categoriesRepository = categoriesRepository ?? throw new ArgumentNullException(nameof(categoriesRepository));
			this.base64Converter = base64Converter ?? throw new ArgumentNullException(nameof(base64Converter));
		}
		public IEnumerable<CategoryVM> GetCategories()
		{
			return categoriesRepository.GetAll().Select(c => new CategoryVM
			{
				Id = c.CategoryId,
				Name = c.CategoryName,
				Description = c.Description,
				Base64Picture = base64Converter.FromBinary(c.Picture),
			});
		}
	}
}
