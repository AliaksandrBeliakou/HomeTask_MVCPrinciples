using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [HttpGet]
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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = context.Products.Select(p => new ProductEditVM
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                CategoryID = p.CategoryID,
                SupplierID = p.SupplierID,
                QuantityPerUnit = p.QuantityPerUnit,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock,
                UnitsOnOrder = p.UnitsOnOrder,
                ReorderLevel = p.ReorderLevel,
                Discontinued = p.Discontinued,
            }).Single(p => p.ProductId == id);

            ViewBag.CategoriesDropDownOptions = context.Categories
                .Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.CategoryName, Selected = c.CategoryId == product.CategoryID });
            ViewBag.SupliersDropDownOptions = context.Suppliers
                .Select(s => new SelectListItem { Value = s.SupplierId.ToString(), Text = s.CompanyName, Selected = s.SupplierId == product.SupplierID });

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductEditVM product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var productEntity = context.Products.Find(product.ProductId);
            if(productEntity == null)
            {
                throw new DbUpdateException($"Product with id equal {product.ProductId} is not exist.");
            }

            productEntity.ProductName = product.ProductName;
            productEntity.CategoryID = product.CategoryID;
            productEntity.SupplierID = product.SupplierID;
            productEntity.QuantityPerUnit = product.QuantityPerUnit;
            productEntity.UnitPrice = product.UnitPrice;
            productEntity.UnitsInStock = product.UnitsInStock;
            productEntity.UnitsOnOrder = product.UnitsOnOrder;
            productEntity.ReorderLevel = product.ReorderLevel;
            productEntity.Discontinued = product.Discontinued;
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
