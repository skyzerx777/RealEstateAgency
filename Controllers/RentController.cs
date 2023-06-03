using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateAgency.Models;

namespace RealEstateAgency.Controllers
{
    public class RentController : Controller
    {
        private readonly RealEstateAgencyContext _context;

        public RentController(RealEstateAgencyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var propertiesForRent = await _context.Properties.Where(p => p.IsForRent).ToListAsync();
            return View(propertiesForRent);
        }
    }
}
