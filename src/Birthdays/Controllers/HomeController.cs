using Birthdays.Database;
using Birthdays.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Diagnostics;

namespace Birthdays.Controllers
{
    public class HomeController : Controller
    {
        private readonly BirthdaysDbContext _context;

        public HomeController(BirthdaysDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Birthdays.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] BirthdayRegister value)
        {
            if (ModelState.IsValid)
            {
                value.Id = Guid.NewGuid().ToString();
                await _context.AddAsync(value);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}