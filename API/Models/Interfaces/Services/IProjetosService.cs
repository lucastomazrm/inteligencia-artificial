using System.Collections.Generic;

namespace Models.Interfaces.Services
{
    public interface IProjetosService
    {
        void Add(Projeto item);
        IEnumerable<Projeto> All();
        void Delete(long id);
        Projeto Get(long id);
        void Update(Projeto item);
    }
}
