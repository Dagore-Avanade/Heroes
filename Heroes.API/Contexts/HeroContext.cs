using Heroes.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Heroes.API.Contexts
{
    public class HeroContext : DbContext
    {
        public HeroContext(DbContextOptions<HeroContext> options): base(options) {}

        public DbSet<Hero> Heroes { get; set; } = null!;
    }
}
