using Microsoft.EntityFrameworkCore;
using phonebook_core.Entities;

namespace phonebook_infrastructure
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options)
        {

        }

        public DbSet<PhoneBookEntry> PhoneBook { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PhoneBookEntryEntityTypeConfiguration());
        }
    }
}