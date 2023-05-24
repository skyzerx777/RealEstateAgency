using Microsoft.AspNetCore.Mvc;

namespace RealEstateAgency.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
