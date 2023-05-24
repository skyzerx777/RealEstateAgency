using Microsoft.AspNetCore.Mvc;

namespace RealEstateAgency.Controllers
{
    public class ReviewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
