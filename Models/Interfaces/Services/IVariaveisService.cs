using System.Collections.Generic;

namespace Models.Interfaces.Services
{
    public interface IVariaveisService
    {
        void Add(Variavel item);
        IEnumerable<Variavel> AllProblems(long id);
        IEnumerable<Variavel> AllProject(long id);
        void Delete(long id);
        Variavel Get(long id);
        void Update(Variavel item);
    }
}
