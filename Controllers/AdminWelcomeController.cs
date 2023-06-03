using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateAgency.Controllers
{
    [Authorize]
    public class AdminWelcomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
