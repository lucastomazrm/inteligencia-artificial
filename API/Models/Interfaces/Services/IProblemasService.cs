using System.Collections.Generic;

namespace Models.Interfaces.Services
{
    public interface IProblemasService
    {

        /// <summary>
        /// Retorna todos problemas cadastrados do projeto
        /// </summary>
        /// <param name="idProjeto">Id do projeto</param>
        /// <returns>Lista com os Problenas (não inclui variaveis)</returns>
        IEnumerable<Problema> All(long idProjeto);


        /// <summary>
        /// Retorna o problema com suas variaveis
        /// </summary>
        /// <param name="id">Id do problema</param>
        /// <returns></returns>
        Problema Get(long id);

        /// <summary>
        /// Cria um problema
        /// </summary>
        /// <param name="item">Problmea</param>
        void Add(Problema item);

        /// <summary>
        /// Cria o relacionamento 
        /// </summary>
        /// <param name="idProblema"></param>
        /// <param name="idVariaveis"></param>
        void AddVariaies(long idProblema, IEnumerable<long> idVariaveis);

        /// <summary>
        /// Atualiza o Problema
        /// </summary>
        /// <param name="item"></param>
        void Update(Problema item);

        /// <summary>
        /// Deleta o Problema e a relação entre os problemas
        /// </summary>
        /// <param name="id">Id do Problema</param>
        void Delete(long id);
    }
}
