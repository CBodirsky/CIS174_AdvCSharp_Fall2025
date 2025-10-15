using Microsoft.AspNetCore.Mvc;
using MainSite.Views.Olympics;

namespace MainSite.Controllers
{
    public class OlympicDataController : Controller
    {
        public IActionResult Index()
        {
            var countries = OlympicData.GetAll();
            return View(countries);
        }

        public IActionResult Filter(string game, string category)
        {
            ViewData["CurrentGame"] = game;
            ViewData["CurrentCategory"] = category;

            var filtered = OlympicData.Filter(game, category);
            return View(filtered);
        }

        [HttpPost]
        public IActionResult AddToFavorites(string key)
        {
            FavoriteManager.AddFavorite(HttpContext.Session, key);
            return RedirectToAction("Index");
        }

    }
}
