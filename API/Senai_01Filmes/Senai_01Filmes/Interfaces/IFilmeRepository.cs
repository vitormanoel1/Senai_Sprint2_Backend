using Senai_01Filmes.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_01Filmes.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório FilmeRepository
    /// </summary>
    interface IFilmeRepository
    {
        // TipoRetorno NomeMetodo(TipoParametro NomeParametro);

        /// <summary>
        /// Lista todos os Filmes
        /// </summary>
        /// <returns> Lista de filmes </returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Buscar um filme pelo seu id
        /// </summary>
        /// <param name="IdFilme"> id do filme que será buscado </param>
        /// <returns> Um objeto Filme que foi buscado </returns>
        FilmeDomain BuscarPorId(int IdFilme);

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="NovoFilme"> Objeto NovoFilme com as informações cadastradas </param>
        void Cadastrar(FilmeDomain NovoFilme);

        /// <summary>
        /// Atualiza um filme existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="filme"> Objeto filme com as novas informações </param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualiza um filme existente passando o id pela url da requisição
        /// </summary>
        /// <param name="IdFilme"> id do filme que será atualizado </param>
        /// <param name="filme"> Objeto filme com as novas informações </param>
        void AtualizarIdUrl(int IdFilme, FilmeDomain filme);

        /// <summary>
        /// Deletar um filme existente
        /// </summary>
        /// <param name="IdFilme"> id do filme que será ultilizado para deletar tal filme </param>
        void Deletar(int IdFilme);
    }
}
