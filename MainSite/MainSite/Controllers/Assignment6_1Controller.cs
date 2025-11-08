using Microsoft.AspNetCore.Mvc;
using MainSite.Models;
using System.Security.Principal;

namespace MainSite.Controllers
{
    public class Assignment6_1Controller : Controller
    {
        public IActionResult Index(int accessLevel)
        {
            if (accessLevel < 1 || accessLevel > 10)
            {
                return BadRequest("Access level must be between 1 and 10");
            }

            var students = new List<Student>
    {
        new Student { FirstName = "Alice", LastName = "Alternate", Grade = "A" },
        new Student { FirstName = "Ben", LastName = "Bobby", Grade = "B+" },
        new Student { FirstName = "Cara", LastName = "Colbolt", Grade = "C-" }
    };
            var viewModel = new StudentViewModel
            {
                Students = students,
                AccessLevel = accessLevel
            };
            return View(viewModel);
        }
    }
}
