using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BilgeShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")] // program.cs'teki area:exists kısmı ile eşlenir.
    [Authorize(Roles="Admin")] // Claimler'deki claims.Add(new Claim(ClaimTypes.Role, userDto.UserType.ToString())); ile bağlantılı (authController).

    // yukarıda yazdığım authorize sayesinde, yetkisi admin olmayan kişiler, bu controller'a istek atamaz.
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}


// Adminin ana sayfası