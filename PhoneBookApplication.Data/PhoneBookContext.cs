using Microsoft.EntityFrameworkCore;
using PhoneBookApplication.Domain.Entities;

namespace PhoneBookApplication.Data
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<PhoneBookAggregateRoot> PhoneBooks { get; set; }
        public DbSet<Entry> Entries { get; set; }

    }
}
