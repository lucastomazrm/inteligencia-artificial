using System.Collections.Generic;

namespace Models.Interfaces.Services
{
    public interface IProblemasService
    {
        void Add(Problema item);
        IEnumerable<Problema> All(long id);
        void Delete(long id);
        Problema Get(long id);
        void Update(Problema item);
    }
}
