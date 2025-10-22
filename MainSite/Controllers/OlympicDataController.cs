using MainSite.Models;
using MainSite.Views.Olympics;
using Microsoft.AspNetCore.Mvc;

namespace MainSite.Controllers
{
    public class OlympicDataController : Controller
    {
        public IActionResult Index()
        {
            var countries = OlympicData.GetAll();
            return View(countries);
        }

        public IActionResult Filter(OlympicFilterViewModel filter)
        {
            ViewData["CurrentGame"] = filter.Game;
            ViewData["CurrentCategory"] = filter.Category;

            var filtered = OlympicData.Filter(filter.Game, filter.Category);
            return View(filtered);
        }
        //public IActionResult Filter(string game, string category)

        //{
        //    ViewData["CurrentGame"] = game;
        //    ViewData["CurrentCategory"] = category;

        //    var filtered = OlympicData.Filter(game, category);
        //    return View(filtered);
        //}

        [HttpPost]
        public IActionResult AddToFavorites(string key)
        {
            FavoriteManager.AddFavorite(HttpContext.Session, key);
            return RedirectToAction("Index");
        }

    }
}
