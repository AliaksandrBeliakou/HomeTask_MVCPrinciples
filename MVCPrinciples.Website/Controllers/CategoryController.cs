using Microsoft.AspNetCore.Mvc;
using MVCPrinciples.Website.Data;
using MVCPrinciples.Website.Services;

namespace MVCPrinciples.Website.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ILogger<HomeController> logger;
		private readonly ICategoriesService categoriesService;

		public CategoryController(ILogger<HomeController> logger, ICategoriesService categoriesService, NorthwindContext context)
		{
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
			this.categoriesService = categoriesService ?? throw new ArgumentNullException(nameof(categoriesService));
		}

		public IActionResult Index()
		{
			logger.LogInformation("Get categories");
			var categories = categoriesService.GetCategories();
			return View(categories);
		}
	}
}
