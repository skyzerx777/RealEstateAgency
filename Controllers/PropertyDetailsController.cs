using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Models;

namespace RealEstateAgency.Controllers
{
    public class PropertyDetailsController : Controller
    {
        private readonly RealEstateAgencyContext _context;

        public PropertyDetailsController(RealEstateAgencyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _context.Properties.FindAsync(id);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }
    }

}
