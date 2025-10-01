using Microsoft.AspNetCore.Mvc;

namespace MainSite.Controllers
{
    public class RoutingController : Controller
    {
        public IActionResult DefaultPage()
        {
            ViewBag.Title = "Default Routing Page";
            return View();
        }

        public IActionResult CustomRulePage()
        {
            ViewBag.Title = "Custom Rule Routing Page";
            return View();
        }

        [Route("attribute-path/attribute-page")]
        public IActionResult AttributePage()
        {
            ViewBag.Title = "Custom Attribute Routing Page";
            return View();
        }
    }
}
