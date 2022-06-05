using Microsoft.AspNetCore.Mvc;

namespace MVCPrinciples.Website.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ProductController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
