using BilgeShop.Business.Manager;
using BilgeShop.Business.Services;
using BilgeShop.Data.Context;
using BilgeShop.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // -> Bu bir MVC projesidir demek i�in buray� yazman gerek...!!!


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BilgeShopContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));
// IRepository tipinde bir new'leme yap�ld���nda (Dep.Inj.) - SqlRepository kopyas� olu�tur. AddScoped -> Her istek'te yeni bir kopya olu�tur.  

builder.Services.AddScoped<IUserService, UserManager>();
// IUserService tipinde bir DI newlemesi yap�l�rsa, UserManager kullan�lacak demek.

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddDataProtection();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.LogoutPath = new PathString("/");
    options.AccessDeniedPath = new PathString("/");

    // Oturum a��lmada, oturum kapatmada, ya da bir oturumsal/yetkisel hatada url'e ne olaca��n� belirledi�i k�s�m.

});



var app = builder.Build();


app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles(); // wwwroot kulland���m�z i�in buraya ekledik.


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );

app.MapDefaultControllerRoute();

app.Run();
