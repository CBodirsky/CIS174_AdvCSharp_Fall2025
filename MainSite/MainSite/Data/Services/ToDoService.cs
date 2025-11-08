using MainSite.Models;
using MainSite.Data.Repositories;

namespace MainSite.Data.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _repo;
        public ToDoService(IToDoRepository repo) => _repo = repo;

        public async Task<Ticket> CreateAsync(string name, string description, int sprintNumber, int pointValue, TicketStatus status)
        {
            var ticket = new Ticket
            {
                Name = name,
                Description = description,
                SprintNumber = sprintNumber,
                PointValue = pointValue,
                Status = status
            };

            await _repo.AddAsync(ticket);
            await _repo.SaveChangesAsync();
            return ticket;
        }

        public Task<List<Ticket>> GetAllAsync() => _repo.GetAllAsync();
    }
}
