using Microsoft.EntityFrameworkCore;
using MVCPrinciples.Website.Data;
using MVCPrinciples.Website.MiddleWare;
using MVCPrinciples.Website.Ropositories;
using MVCPrinciples.Website.Ropositories.Interfaces;
using MVCPrinciples.Website.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("NorthwindDb");
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(connection));
builder.Services.AddTransient<ICategoriesService, CategoriesService>();
builder.Services.AddTransient<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddTransient<IProductsService, ProductsService>();
builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
builder.Services.AddTransient<ISuppliersRepository, SuppliersRepository>();
builder.Services.AddSingleton<Base64Converter>();
builder.Services.AddTransient<DropDownMenuService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

var logger = app.Services.GetService<ILoggerFactory>()!.CreateLogger<GlobalErrorHandler>();

app.UseMiddleware<GlobalErrorHandler>(logger);
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
