using Microsoft.EntityFrameworkCore;
using PhoneBookApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApplication.Data
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public const string DEFAULT_SCHEMA = "dbo";
        public DbSet<PhoneBookAggregateRoot> PhoneBooks { get; set; }
        public DbSet<Entry> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PhoneBookTypeConfiguration());
        }

    }
}
