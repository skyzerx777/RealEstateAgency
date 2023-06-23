using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RealEstateAgency.Models;

namespace RealEstateAgency.Controllers
{
    [Authorize]
    public class CustomerRequestsController : Controller
    {
        private readonly RealEstateAgencyContext _context;

        public CustomerRequestsController(RealEstateAgencyContext context)
        {
            _context = context;
        }

        // GET: CustomerRequests
        public async Task<IActionResult> Index()
        {
              return _context.CustomerRequests != null ? 
                          View(await _context.CustomerRequests.ToListAsync()) :
                          Problem("Entity set 'RealEstateAgencyContext.CustomerRequests'  is null.");
        }

        // GET: CustomerRequests/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.CustomerRequests == null)
            {
                return NotFound();
            }

            var customerRequest = await _context.CustomerRequests
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (customerRequest == null)
            {
                return NotFound();
            }

            return View(customerRequest);
        }

        // GET: CustomerRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestID,PropertyID,Name,PhoneNumber,Email")] CustomerRequest customerRequest)
        {
            if (ModelState.IsValid)
            {
                customerRequest.RequestID = Guid.NewGuid();
                _context.Add(customerRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerRequest);
        }

        // POST: CustomerRequests/CreateFromProperty
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFromProperty(string Name, string PhoneNumber, string Email, Guid PropertyID)
        {
            if (ModelState.IsValid)
            {
                var customerRequest = new CustomerRequest
                {
                    RequestID = Guid.NewGuid(),
                    PropertyID = PropertyID,
                    Name = Name,
                    PhoneNumber = PhoneNumber,
                    Email = Email
                };

                _context.Add(customerRequest);
                await _context.SaveChangesAsync();

                TempData["Notification"] = "Запит відправлено";
                return RedirectToAction("Index", "PropertyDetails", new { id = PropertyID });
            }

            return RedirectToAction("Index", "PropertyDetails", new { id = PropertyID });
        }

        // GET: CustomerRequests/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.CustomerRequests == null)
            {
                return NotFound();
            }

            var customerRequest = await _context.CustomerRequests.FindAsync(id);
            if (customerRequest == null)
            {
                return NotFound();
            }
            return View(customerRequest);
        }

        // POST: CustomerRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("RequestID,PropertyID,Name,PhoneNumber,Email")] CustomerRequest customerRequest)
        {
            if (id != customerRequest.RequestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerRequestExists(customerRequest.RequestID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customerRequest);
        }

        // GET: CustomerRequests/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.CustomerRequests == null)
            {
                return NotFound();
            }

            var customerRequest = await _context.CustomerRequests
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (customerRequest == null)
            {
                return NotFound();
            }

            return View(customerRequest);
        }

        // POST: CustomerRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.CustomerRequests == null)
            {
                return Problem("Entity set 'RealEstateAgencyContext.CustomerRequests'  is null.");
            }
            var customerRequest = await _context.CustomerRequests.FindAsync(id);
            if (customerRequest != null)
            {
                _context.CustomerRequests.Remove(customerRequest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerRequestExists(Guid id)
        {
          return (_context.CustomerRequests?.Any(e => e.RequestID == id)).GetValueOrDefault();
        }
    }
}
