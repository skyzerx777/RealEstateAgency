using Microsoft.AspNetCore.Mvc;

namespace RealEstateAgency.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
