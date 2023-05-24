using Microsoft.AspNetCore.Mvc;

namespace RealEstateAgency.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
