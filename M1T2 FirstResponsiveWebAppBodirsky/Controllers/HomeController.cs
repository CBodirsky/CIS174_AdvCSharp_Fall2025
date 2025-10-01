using System.Diagnostics;
using M1T2_FirstResponsiveWebAppBodirsky.Models;
using Microsoft.AspNetCore.Mvc;

namespace M1T2_FirstResponsiveWebAppBodirsky.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.TodayAge = 0;
            ViewBag.ThisYearAge = 0;
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserAgeModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.TodayAge = model.AgeToday();
                ViewBag.ThisYearAge = model.AgeThisYear();
            }
            else
            {
                ViewBag.TodayAge = 0;
                ViewBag.ThisYearAge = 0;
            }
            return View(model);
        }
    }
}
