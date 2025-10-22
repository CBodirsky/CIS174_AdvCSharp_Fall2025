using MainSite.Models;
using Microsoft.EntityFrameworkCore;

namespace MainSite.Views.ToDoList
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options) { }

        public DbSet<Ticket> Tickets { get; set; } = null!;
    }

}
