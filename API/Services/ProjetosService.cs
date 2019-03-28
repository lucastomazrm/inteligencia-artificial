using IA.inteligencia_artificial.DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IA.inteligencia_artificial.Services
{
    public class ProjetosService : Service, IProjetosService
    {
        public ProjetosService(MainContext context) : base (context)
        {
                
        }
        public IEnumerable<Projeto> All()
        {
            var query = this.context.Set<Projeto>().AsQueryable();
            return query;
        }
        public Projeto Get(long id)
        {
            var query = this.context.Set<Projeto>().AsQueryable();
            foreach (var property in this.context.Model.FindEntityType(typeof(Projeto)).GetNavigations())
            {
                query = query.Include(property.Name);
            }
            return query.FirstOrDefault(x => x.Id == id);
        }
        public void Add(Projeto item)
        {
            this.context.Set<Projeto>().Add(item);
            base.Save();
        }
        public void Update(Projeto item)
        {
            this.context.Set<Projeto>().Attach(item);
            this.context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            base.Save();
        }
        public void Delete(long id)
        {
            var item = this.Get(id);
            this.context.Set<Projeto>().Remove(item);
            base.Save();
        }
    }
}
