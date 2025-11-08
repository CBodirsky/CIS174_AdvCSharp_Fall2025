using MainSite.Views.Olympics;
using Microsoft.AspNetCore.Mvc;

public class FavoritesController : Controller
{
    public IActionResult Index()
    {
        var keys = FavoriteManager.GetFavorites(HttpContext.Session);
        var entries = OlympicData.GetAll()
            .Where(e => keys.Contains(e.GetKey()))
            .OrderBy(e => e.Country)
            .ToList();

        return View(entries);
    }


    [HttpPost]
    public IActionResult Clear()
    {
        FavoriteManager.ClearFavorites(HttpContext.Session);
        return RedirectToAction("Index");
    }
}
