using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_01Filmes.Domains;
using Senai_01Filmes.Interfaces;
using Senai_01Filmes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsavel pelos endpoints(pontos onde uma requisição é feita) referentes aos generos
/// </summary>
namespace Senai_01Filmes.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define a rota de um requisição será no formato dominio/api/NomeController
    // Ex http://Localhost:5000/api/generos
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Objeto _GeneroRepository que irá receber todos os métodos definidos na interface IGeneroRepository 
        /// </summary>
        private IGeneroRepository _GeneroRepository { get; set; }

        /// <summary>
        /// Instancia o objeyo _GeneroRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public GenerosController()
        {
            _GeneroRepository = new GeneroRepository();
        }

        /// <summary>
        ///  Lista todos os gêneros
        /// </summary>
        /// <returns> Lista de generos e um status code</returns>
        [HttpGet]
        public IActionResult Listando()
        {
            // Cria uma lista nomeada ListaGeneros para receber os dados 
            List<GeneroDomain> ListaGeneros = _GeneroRepository.ListarTodos();

            // Retorna o status code 200 (Ok) e a lsita de generos no formato JSON
            return Ok(ListaGeneros);
        }

        /// <summary>
        /// Busca um gênero através do seu id
        /// </summary>
        /// <param name="id">id do gênero que será buscado</param>
        /// <returns>Um gênero buscado ou NotFound caso nenhum gênero seja encontrado</returns>
        /// http://localhost:5000/api/generos/1
        [HttpGet("{id}")]
        public IActionResult GetById(int IdGenero)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            GeneroDomain GeneroBuscado = _GeneroRepository.BuscarPorId(IdGenero);

            // Verifica se nenhum gênero foi encontrado
            if (GeneroBuscado == null)
            {
                // Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                return NotFound("Nenhum gênero encontrado!");
            }

            // Caso seja encontrado, retorna o gênero buscado com um status code 200 - Ok
            return Ok(GeneroBuscado);
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <returns> Retorna o status code 201</returns>
        /// Http://localhost:500/api/generos
        [HttpPost]
        public IActionResult Post(GeneroDomain NovoGenero)
        {
            // Faz a chamada para o método .Cadastrar()
            _GeneroRepository.Cadastrar(NovoGenero);

            // Retorna o status code 201 = Created
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um gênero existente passando o seu id pela url da requisição
        /// </summary>
        /// <param name="id">id do gênero que será atualizado</param>
        /// <param name="generoAtualizado">Objeto generoAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        /// http://localhost:5000/api/generos/3
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int IdGenero, GeneroDomain GeneroAtualizado)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            GeneroDomain GeneroBuscado = _GeneroRepository.BuscarPorId(IdGenero);

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para apresentar que houve erro
            if (GeneroBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Gênero não encontrado!",
                            erro = true
                        }
                    );
            }

            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o método .AtualizarIdUrl()
                _GeneroRepository.AtualizarIdUrl(IdGenero, GeneroAtualizado);

                // Retorna um status code 204 - No Content
                return NoContent();
            }
            // Caso ocorra algum erro
            catch (Exception codErro)
            {
                // Retorna um status code 400 - BadRequest e o código do erro
                return BadRequest(codErro);
            }
        }

        /// <summary>
        /// Atualiza um gênero existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="generoAtualizado">Objeto generoAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain GeneroAtualizado)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            GeneroDomain GeneroBuscado = _GeneroRepository.BuscarPorId(GeneroAtualizado.IdGenero);

            // Verifica se algum gênero foi encontrado
            if (GeneroBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .AtualizarIdCorpo()
                    _GeneroRepository.AtualizarIdCorpo(GeneroAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception codErro)
                {
                    // Retorna BadRequest com o código do erro
                    return BadRequest(codErro);
                }
            }

            // Caso não seja encontrado, retorna NotFoun com uma mensagem personalizada
            return NotFound
                (
                    new
                    {
                        mensagem = "Gênero não encontrado!"
                    }
                );
        }

        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="IdGenero">id do gênero que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// http://localhost:5000/api/generos/11
        [HttpDelete("{IdGenero}")]
        public IActionResult Delete(int IdGenero)
        {
            // Faz a chamada para o método .Deletar()
            _GeneroRepository.Deletar(IdGenero);

            // Retorna um status code 204 - No Content
            return StatusCode(204);
        }
    }
}
