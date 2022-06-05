using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCPrinciples.Website.Data;
using MVCPrinciples.Website.Models;

namespace MVCPrinciples.Website.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly NorthwindContext context;
        private readonly int productOnPageAmount;

        public ProductController(NorthwindContext context, ILogger<HomeController> logger, IConfiguration configuratrion)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.productOnPageAmount = configuratrion?.GetValue<int>("ProductsOnPageAmount") ?? throw new ArgumentNullException(nameof(configuratrion));
        }

        public IActionResult Index()
        {
            var products = context.Products.Include(p => p.Category).Include(p => p.Supplier).Select(p => new ProductVM
            {
                Id = p.ProductId,
                Name = p.ProductName,
                Category = p.Category.CategoryName,
                Supplier = p.Supplier.CompanyName,
                QuantityPerUnit = p.QuantityPerUnit,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock,
                UnitsOnOrder = p.UnitsOnOrder,
                ReorderLevel = p.ReorderLevel,
                Discontinued = p.Discontinued,
            });
            if (productOnPageAmount > 0)
            {
                products = products.Take(productOnPageAmount);
            }

            return View(products);
        }
    }
}
