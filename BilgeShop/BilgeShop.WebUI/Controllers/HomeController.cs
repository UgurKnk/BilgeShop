using Microsoft.AspNetCore.Mvc;

namespace BilgeShop.WebUI.Controllers
{
    public class HomeController : Controller
    {                                                
        [Route("/")]
        [Route("urunler/{categoryName}/{categoryId}")]
        public IActionResult Index(int? categoryId)   // Debug 08.03.2023
        {
            ViewBag.CategoryId = categoryId;

            return View();
        }
    }
}
