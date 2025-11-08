using MainSite.Models;
namespace MainSite.Data.Repositories
{
    public interface IToDoRepository
    {
        Task<Ticket?> GetByIdAsync(int id);
        Task<List<Ticket>> GetAllAsync();
        Task AddAsync(Ticket ticket);
        Task UpdateAsync(Ticket ticket);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
