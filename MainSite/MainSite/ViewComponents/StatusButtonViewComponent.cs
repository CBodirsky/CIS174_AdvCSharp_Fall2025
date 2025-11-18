using Microsoft.AspNetCore.Mvc;

namespace MainSite.ViewComponents
{
    public class StatusButtonViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(MainSite.Models.TicketStatus status)
        {
            return View("Default", status);
        }
    }
}
