using MVCPrinciples.Website.Data;
using MVCPrinciples.Website.Data.Entities;
using MVCPrinciples.Website.Ropositories.Interfaces;

namespace MVCPrinciples.Website.Ropositories
{
	public class CategoriesRepository : ICategoriesRepository
	{
		private readonly NorthwindContext context;
		public CategoriesRepository(NorthwindContext context)
		{
			this.context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public IEnumerable<Category> GetAll()
		{
			return context.Categories.ToList();
		}
	}
}
