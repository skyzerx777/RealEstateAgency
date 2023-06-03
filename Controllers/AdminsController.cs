using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateAgency.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace RealEstateAgency.Controllers
{
    [Authorize]
    public class AdminsController : Controller
    {
        private readonly RealEstateAgencyContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AdminsController(RealEstateAgencyContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Admins
        [Authorize(Roles = "master")]
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }


        // GET: Admins/Details/5
        [Authorize(Roles = "master")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var admin = await _userManager.FindByIdAsync(id.ToString());

            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: Admins/Create
        [Authorize(Roles = "master")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "master")]
        public async Task<IActionResult> Create(AdminRegistrationViewModel registrationViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = registrationViewModel.Username };

                var result = await _userManager.CreateAsync(user, registrationViewModel.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "admin");

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(registrationViewModel);
        }

        // GET: Admins/Edit/5
        [Authorize(Roles = "master")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var admin = await _userManager.FindByIdAsync(id.ToString());

            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: Admins/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "master")]
        public async Task<IActionResult> Edit(Guid id, IdentityUser admin)
        {
            if (id != Guid.Parse(admin.Id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(admin.Id);

                if (user == null)
                {
                    return NotFound();
                }

                user.UserName = admin.UserName;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(admin);
        }

        // GET: Admins/Delete/5
        [Authorize(Roles = "master")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var admin = await _userManager.FindByIdAsync(id.ToString());

            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "master")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'RealEstateAgencyContext.Users' is null.");
            }

            var admin = await _userManager.FindByIdAsync(id.ToString());

            if (admin != null)
            {
                await _userManager.DeleteAsync(admin);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
