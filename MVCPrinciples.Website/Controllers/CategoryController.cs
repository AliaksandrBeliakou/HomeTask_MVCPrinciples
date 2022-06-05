using Microsoft.AspNetCore.Mvc;

namespace MVCPrinciples.Website.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public CategoryController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
