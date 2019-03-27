using System;
using Microsoft.EntityFrameworkCore;
using Models;

namespace IA.inteligencia_artificial.DataAccess
{
    public partial class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Problema> Problemas { get; set; }
        public DbSet<ProblemaVariavel> ProblemasVariaveis { get; set; }
        public DbSet<Variavel> Variaveis { get; set; }
    }
}
