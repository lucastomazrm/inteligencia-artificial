using System;
using Microsoft.EntityFrameworkCore;

namespace IA.inteligencia_artificial.DataAccess
{
    public partial class MainContext : DbContext
    {
        // public DbSet<UserPreference> UserPreferences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // UserPreferenceMap(modelBuilder);
        }
    }
}
