
using Microsoft.EntityFrameworkCore;

namespace Phone_Contacts.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options) 
        { }

        public DbSet<Contact> Contacts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    Name = "Jimmy John",
                    Number = "123-456-7890",
                    Note = "Cool guy",
                    Street = "321 C St",
                    City = "Other Faketown",
                    State = "IA",
                    Zip = "50388"
                },

                new Contact
                {
                    ContactId = 2,
                    Name = "Susan Sue",
                    Number = "987-645-3210",
                    Note = "Owes me $5",
                    Street = "210 Fake St Apt 13",
                    City = "Realtown",
                    State = "IA",
                    Zip = "50350"
                },
                new Contact
                {
                    ContactId = 3,
                    Name = "Carl Guy",
                    Number = "111-222-3333",
                    Note = "",
                    Street = "1 Solo Rd",
                    City = "Faketown",
                    State = "IA",
                    Zip = "50399"
                }
            );
        }
    }
}
