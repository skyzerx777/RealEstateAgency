using Microsoft.AspNetCore.Mvc;

namespace RealEstateAgency.Controllers
{
    public class RentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
