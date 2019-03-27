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
    public class VariaveisService : Service, IVariaveisService
    {
        public VariaveisService(MainContext context) : base(context)
        {

        }

        public IEnumerable<Variavel> AllProject(long id)
        {
            var query = this.context.Set<Variavel>()
                                    .AsQueryable()
                                    .Where(x => x.ProjetoId == id);

            foreach (var property in this.context.Model.FindEntityType(typeof(Variavel)).GetNavigations())
            {
                query = query.Include(property.Name);
            }

            return query;
        }
        public IEnumerable<Variavel> AllProblems(long id)
        {
            var query = this.context.Set<ProblemaVariavel>()
                                    .AsQueryable()
                                    .Where(x => x.ProblemaId == id);

            foreach (var property in this.context.Model.FindEntityType(typeof(Variavel)).GetNavigations())
            {
                query = query.Include(property.Name);
            }

            return query.Select(x => x.Varivavel);
        }
        public Variavel Get(long id)
        {
            var query = this.context.Set<Variavel>().AsQueryable();
            foreach (var property in this.context.Model.FindEntityType(typeof(Variavel)).GetNavigations())
            {
                query = query.Include(property.Name);
            }
            return query.FirstOrDefault(x => x.Id == id);
        }
        public void Add(Variavel item)
        {
            this.context.Set<Variavel>().Add(item);
            base.Save();
        }
        public void Update(Variavel item)
        {
            this.context.Set<Variavel>().Attach(item);
            this.context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            base.Save();
        }
        public void Delete(long id)
        {
            var item = this.Get(id);
            this.context.Set<Variavel>().Remove(item);
            base.Save();
        }
    }
}
