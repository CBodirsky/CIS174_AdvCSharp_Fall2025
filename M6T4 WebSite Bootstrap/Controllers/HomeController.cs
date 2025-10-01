using System.Diagnostics;
using MainSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MainSite.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext context { get; set; }

        //public HomeController(ContactContext ctx) => context = ctx;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ContactContext ctx, ILogger<HomeController> logger)
        {
            context = ctx;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var contacts = context.Contacts.Include(m => m.Address).OrderBy(m => m.Name).ToList();
            var contacts = context.Contacts.OrderBy(m => m.Name).ToList();
            return View(contacts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
