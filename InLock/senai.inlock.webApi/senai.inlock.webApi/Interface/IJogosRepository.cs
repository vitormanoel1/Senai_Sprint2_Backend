using senai.inlock.webApi_.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interface
{
    interface IJogosRepository
    {
        /// <summary>
        /// lista todos os jogos
        /// </summary>
        /// <returns> uma lista jogos</returns>
        List<JogosDomain> ListarTodos();

        /// <summary>
        /// busca um jogo através do seu id 
        /// </summary>
        /// <param name="Id"> id do jogo que será buscado</param>
        /// <returns> um objeto jogo que foi buscado</returns>
        JogosDomain BuscarPorId(int Id);
        /// <summary>
        /// atualiza um jojo existente passando o id pela url da requisição 
        /// </summary>
        /// <param name="Id"> id do jogo que será atualizado</param>
        /// <param name="JogoAtualizado"> objeto genero que com as novas informações</param>
        void AtualizarIdUrl(int Id, JogosDomain JogoAtualizado);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NovoJogo"></param>
        void Cadastrar(JogosDomain NovoJogo);

        /// <summary>
        /// deleta um jogo existente
        /// </summary>
        /// <param name="Id"> id do gênero que será deletado</param>
        void Deletar(int Id);

        List<JogosDomain> ListarPorJogos(int Id);
    }
}
