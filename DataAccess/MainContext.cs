using System;
using Microsoft.EntityFrameworkCore;
using Models;

namespace IA.inteligencia_artificial.DataAccess
{
    public partial class MainContext : DbContext
    {
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Problema> Problemas { get; set; }
        public DbSet<Variavel> Variaveis { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Environment.GetEnvironmentVariable("Server=localhost;Database=Intelegincia;Uid=root;Pwd =;"));
            base.OnConfiguring(optionsBuilder);
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // UserPreferenceMap(modelBuilder);
        }
    }
}
