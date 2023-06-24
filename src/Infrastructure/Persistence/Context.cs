using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var urlDb = "localhost";
            var user = "postgres";
            var password = "minha_senha";
            var db = "TudoVascoDB";
            var port = "5432";
            optionsBuilder.UseNpgsql($"Host={urlDb};Port={port};Username={user};Password={password};Database={db};");
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
    }
}
