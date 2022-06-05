using Microsoft.AspNetCore.Mvc;
using MVCPrinciples.Website.Data;
using MVCPrinciples.Website.Models;

namespace MVCPrinciples.Website.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly NorthwindContext context;

        public CategoryController(ILogger<HomeController> logger, NorthwindContext context)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IActionResult Index()
        {
            var categories = context.Categories.Select(c => new CategoryVM
            {
                Id = c.CategoryId,
                Name = c.CategoryName,
                Description = c.Description,
                Base64Picture = ToBase64(c.Picture),
            });
            return View(categories);
        }

        public IActionResult Photo()
        {
            var categories = context.Categories.Select(c => new CategoryVM
            {
                Id = c.CategoryId,
                Name = c.CategoryName,
                Description = c.Description,
                Base64Picture = ToBase64(c.Picture),
            });
            return View(categories);
        }

        private static string ToBase64(byte[] source)
        {
            var base64Source = source[78..^78];
            var base64Str = Convert.ToBase64String(source[78..^78]);
            return "data:image/jpg;base64," + base64Str;
        }
    }
}
