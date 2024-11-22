using Microsoft.AspNetCore.Mvc;
using WebTest.Models;

namespace WebTest.Controllers
{
    public class PriceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PriceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var services = _context.NameServices.ToList();
            return View(services);
        }
    }
}

