using Microsoft.AspNetCore.Mvc.Rendering;
using MVCPrinciples.Website.Ropositories.Interfaces;

namespace MVCPrinciples.Website.Services
{
	public class DropDownMenuService
	{
		private readonly ISuppliersRepository suppliersRepository;
		private readonly ICategoriesRepository categoriesRepository;

		public DropDownMenuService(ICategoriesRepository categoriesRepository, ISuppliersRepository suppliersRepository)
		{
			this.suppliersRepository = suppliersRepository ?? throw new ArgumentNullException(nameof(suppliersRepository));
			this.categoriesRepository = categoriesRepository ?? throw new ArgumentNullException(nameof(categoriesRepository));
		}

		public IEnumerable<SelectListItem> Categories(int selectedProductId = 0)
		{
			return categoriesRepository.GetAll()
				.Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.CategoryName, Selected = c.CategoryId == selectedProductId });
		}

		public IEnumerable<SelectListItem> Suppliers(int selectedProductId = 0)
		{
			return suppliersRepository.GetAll()
				.Select(s => new SelectListItem { Value = s.SupplierId.ToString(), Text = s.CompanyName, Selected = s.SupplierId == selectedProductId });
		}
	}
}
