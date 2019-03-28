using System.Collections.Generic;

namespace Models.Interfaces.Services
{
    public interface IVariaveisService
    {
        /// <summary>
        /// Adiciona nova variavel
        /// </summary>
        /// <param name="item">model de variavel</param>
        void Add(Variavel item);

        /// <summary>
        /// Todas as variaveis que contem Id problema
        /// </summary>
        /// <param name="id">id do problmea</param>
        /// <returns>Lista de variaveis</returns>
        IEnumerable<Variavel> AllProblems(long id);


        /// <summary>
        /// Todas as variaveis que contem Id projetos
        /// </summary>
        /// <param name="id">id do problmea</param>
        /// <returns>Lista de variaveis</returns>
        IEnumerable<Variavel> AllProject(long id);

        void Delete(long id);
        Variavel Get(long id);
        void Update(Variavel item);
    }
}
