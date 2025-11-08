using MainSite.Models;

namespace MainSite.Data.Services
{
    public interface IToDoService
    {
        Task<Ticket> CreateAsync(string name, string description, int sprintNumber, int pointValue, TicketStatus status);
        Task<List<Ticket>> GetAllAsync();
    }
}
