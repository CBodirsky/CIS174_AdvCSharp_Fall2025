using MainSite.Models;
using MainSite.Views.ToDoList;
using Microsoft.AspNetCore.Mvc;

public class ToDoListController : Controller
{
    private readonly ToDoContext _context;

    public ToDoListController(ToDoContext context)
    {
        _context = context;
    }

    public IActionResult Index(TicketStatus? status)
    {
        var tickets = _context.Tickets.ToList();

        if (status.HasValue)
        {
            tickets = tickets.Where(t => t.Status == status.Value).ToList();
        }

        ViewBag.Tickets = tickets;
        return View(new TicketFilterViewModel {  Status = status });
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Edit(int id)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null)
        {
            return NotFound();
        }
        return View(ticket);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Ticket ticket)
    {
        if (id != ticket.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(ticket);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(ticket);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Ticket ticket)
    {
        if (ModelState.IsValid)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(ticket);
    }

}
