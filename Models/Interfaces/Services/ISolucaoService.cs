using System.Collections.Generic;

namespace Models.Interfaces.Services
{
    public interface ISolucaoService
    {
        IEnumerable<Problema> Diagnosis(IEnumerable<long> variables);
    }
}
