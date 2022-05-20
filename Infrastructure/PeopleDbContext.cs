using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
    }
}
