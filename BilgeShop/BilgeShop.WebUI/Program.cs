using BilgeShop.Business.Manager;
using BilgeShop.Business.Services;
using BilgeShop.Data.Context;
using BilgeShop.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // -> Bu bir MVC projesidir demek için burayý yazman gerek...!!!


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BilgeShopContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));
// IRepository tipinde bir new'leme yapýldýðýnda (Dep.Inj.) - SqlRepository kopyasý oluþtur. AddScoped -> Her istek'te yeni bir kopya oluþtur.  

builder.Services.AddScoped<IUserService, UserManager>();
// IUserService tipinde bir DI newlemesi yapýlýrsa, UserManager kullanýlacak demek.

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddDataProtection();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.LogoutPath = new PathString("/");
    options.AccessDeniedPath = new PathString("/");

    // Oturum açýlmada, oturum kapatmada, ya da bir oturumsal/yetkisel hatada url'e ne olacaðýný belirlediði kýsým.

});



var app = builder.Build();


app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles(); // wwwroot kullandýðýmýz için buraya ekledik.


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );

app.MapDefaultControllerRoute();

app.Run();
