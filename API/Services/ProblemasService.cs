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
    public class ProblemasService : Service, IProblemasService
    {
        public ProblemasService(MainContext context) : base (context)
        {

        }

        public IEnumerable<Problema> All(long idProjeto)
        {
            var query = this.context.Set<Problema>()
                                    .AsQueryable()
                                    .Where(x => x.ProjetoId == idProjeto);

            foreach (var property in this.context.Model.FindEntityType(typeof(Problema)).GetNavigations())
            {
                query = query.Include(property.Name);
            }

            return query;
        }
        public Problema Get(long id)
        {
            var query = this.context.Set<Problema>().AsQueryable();
            foreach (var property in this.context.Model.FindEntityType(typeof(Problema)).GetNavigations())
            {
                query = query.Include(property.Name);
            }
            return query.FirstOrDefault(x => x.Id == id);
        }
        public void Add(Problema item)
        {
            this.context.Set<Problema>().Add(item);
            base.Save();
        }
        public void AddVariaies(long idProblema, IEnumerable<long> idVariaveis)
        {
            foreach (var idVariavel in idVariaveis)
            {
                this.context.Set<ProblemaVariavel>().Add(new ProblemaVariavel(idProblema, idVariavel));                  
            }
            base.Save();
        }
        public void Update(Problema item)
        {
            this.context.Set<Problema>().Attach(item);
            this.context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            base.Save();
        }
        public void Delete(long id)
        {
            var item = this.Get(id);
            this.context.Set<Problema>().Remove(item);
            base.Save();
        }

    }
}
