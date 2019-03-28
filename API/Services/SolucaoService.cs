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
    public class SolucaoService : Service, ISolucaoService
    {
        public SolucaoService(MainContext context) : base(context)
        {

        }

        public IEnumerable<Problema> Solucao(IEnumerable<long> variables)
        {
            var query = this.context.Set<Problema>()
                                    .AsQueryable()
                                    .Where(x => !x.ProblemasVariaveis.Select(y => y.VariavelId).Except(variables).Any());

            foreach (var property in this.context.Model.FindEntityType(typeof(Problema)).GetNavigations())
            {
                query = query.Include(property.Name);
            }

            return query;
        }
    }
}
