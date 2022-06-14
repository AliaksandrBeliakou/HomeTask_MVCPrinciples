using Microsoft.AspNetCore.Mvc;
using MVCPrinciples.Website.Models;
using MVCPrinciples.Website.Services;

namespace MVCPrinciples.Website.Controllers
{
	public class ProductController : Controller
	{
		private readonly ILogger<HomeController> logger;
		private readonly IProductsService productsService;
		private readonly DropDownMenuService dropDownMenuService;

		public ProductController(ILogger<HomeController> logger, IConfiguration configuratrion, IProductsService productsService, DropDownMenuService dropDownMenuService)
		{
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
			this.productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
			this.dropDownMenuService = dropDownMenuService ?? throw new ArgumentNullException(nameof(dropDownMenuService));
		}

		[HttpGet]
		public IActionResult Index()
		{
			logger.LogInformation("Get products list");
			var products = productsService.GetProducts();
			return View(products);
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			logger.LogInformation("Get products for edit");
			var product = productsService.GetProductById(id);
			ViewBag.CategoriesDropDownOptions = dropDownMenuService.Categories(product.CategoryID);
			ViewBag.SupliersDropDownOptions = dropDownMenuService.Suppliers(product.SupplierID);
			return View(product);
		}

		[HttpPost]
		public IActionResult Edit(ProductEditVM product)
		{
			logger.LogInformation("Edit product");
			if (!ModelState.IsValid)
			{
				return View(product);
			}

			productsService.Update(product);
			return RedirectToAction("Index");
		}
	}
}
