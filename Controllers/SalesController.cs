using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateAgency.Models;

namespace RealEstateAgency.Controllers
{
    public class SalesController : Controller
    {
        private readonly RealEstateAgencyContext _context;

        public SalesController(RealEstateAgencyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var propertiesForSale = await _context.Properties.Where(p => !p.IsForRent).ToListAsync();
            return View(propertiesForSale);
        }
    }

}
