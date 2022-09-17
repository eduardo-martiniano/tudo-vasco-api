using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var urlDb = "ec2-44-193-178-122.compute-1.amazonaws.com";
            var user = "boeievfuqlbubs";
            var password = "33825fdc64e6871c72e5920af7c1ee0ad7adbc60813360796943e721b0f8f179";
            var db = "d5iip84lgg5iht";
            var port = "5432";
            optionsBuilder.UseNpgsql($"Host={urlDb};Port={port};Username={user};Password={password};Database={db};");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
    }
}
