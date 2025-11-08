using MainSite.Models;
using Microsoft.AspNetCore.Mvc;
using MainSite.Data.Repositories;

public class ToDoListController : Controller
{
    private readonly IToDoRepository _repo;

    public ToDoListController(IToDoRepository repo)
    {
        _repo = repo;
    }

    public async Task<IActionResult> Index(TicketStatus? status)
    {
        var tickets = await _repo.GetAllAsync();

        if (status.HasValue)
        {
            tickets = tickets.Where(t => t.Status == status.Value).ToList();
        }

        ViewBag.Tickets = tickets;
        return View(new TicketFilterViewModel { Status = status });
    }

    public IActionResult Create()
    {
        return View();
    }

    public async Task<IActionResult> Edit(int id)
    {
        var ticket = await _repo.GetByIdAsync(id);
        if (ticket == null)
        {
            return NotFound();
        }
        return View(ticket);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Ticket ticket)
    {
        if (id != ticket.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _repo.UpdateAsync(ticket);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(ticket);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Ticket ticket)
    {
        if (ModelState.IsValid)
        {
            await _repo.AddAsync(ticket);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(ticket);
    }
}
