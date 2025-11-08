using MainSite.Models;
using Microsoft.EntityFrameworkCore;
using MainSite.Views.ToDoList;

namespace MainSite.Data.Repositories
{

    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoContext _context;

        public ToDoRepository(ToDoContext context)
        {
            _context = context;
        }

        public async Task<Ticket?> GetByIdAsync(int id) =>
            await _context.Tickets.FindAsync(id);

        public async Task<List<Ticket>> GetAllAsync() =>
            await _context.Tickets.ToListAsync();

        public async Task AddAsync(Ticket ticket) =>
            await _context.Tickets.AddAsync(ticket);

        public Task UpdateAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Tickets.FindAsync(id);
            if (item != null)
                _context.Tickets.Remove(item);
        }

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}