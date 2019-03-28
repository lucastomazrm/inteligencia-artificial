using System.Collections.Generic;

namespace Models.Interfaces.Services
{
    public interface ISolucaoService
    {
        /// <summary>
        /// Seleciona todos os problemas que contem as variaveis 
        /// </summary>
        /// <param name="variables"></param>
        /// <returns></returns>
        IEnumerable<Problema> Solucao(IEnumerable<long> variables);
    }
}
