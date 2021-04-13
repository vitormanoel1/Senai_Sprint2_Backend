using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsável pelos endpoints referentes aos funcionarios
/// </summary>
namespace Senai.Peoples.WebApi.Controllers
{
    // Define que o tipo de resposta da API será no formato json
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/funcionarios
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        /// <summary>
        /// Objeto _funcionarioRepository que irá receber todos os métodos definidos na interface IFuncionarioRepository
        /// </summary>
        private IFuncionarioRepository _FuncionarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _Funcionarioepository para que haja a referência aos métodos no repositório
        /// </summary>
        public FuncionarioController()
        {
            _FuncionarioRepository = new FuncionarioRepository();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma Lista de funcionario e um status code</returns>
        /// http://localhost:5000/api/funcionarios
        [HttpGet]
        public IActionResult Get()
        {
            // cria uma lista nomeada listaFuncionario para receber os dados
            List<FuncionarioDomain> ListaFuncionarios = _FuncionarioRepository.ListarTodos();

            // retorna o status code 200 (Ok) com a lista de funcionario no formato JSON
            return Ok(ListaFuncionarios);
        }

        /// <summary>
        /// Busca um funcionario através do seu id
        /// </summary>
        /// <param name="IdFun"> Id do funcionario que será buscado</param>
        /// <returns> Um funcionario buscado ou NotFound caso nenhum seja encontrado</returns>
        /// http://localhost:5000/api/funcionarios/1
        [HttpGet("{id}")]
        public IActionResult GetById(int IdFun)
        {
            FuncionarioDomain FuncionarioBuscado = _FuncionarioRepository.BuscaPorId(IdFun);

            if (FuncionarioBuscado == null)
            {
                // Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                return NotFound("Nenhum funcionario foi encontrado!!");
            }

            // Caso seja encontrado, retorna o funcionario buscado com um status code 200 - Ok
            return Ok(FuncionarioBuscado);
        }

        /// <summary>
        /// Cadastra um novo funcionario
        /// </summary>
        /// <returns> Um status code 201 - Created</returns>
        /// http://localhost:5000/api/funcionarios
        [HttpPost]
        public IActionResult Post(FuncionarioDomain NovoGenero)
        {
            // Faz a chamada para o método .Cadastrar()
            _FuncionarioRepository.Cadastrar(NovoGenero);

            // Retorna um status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um funcionario existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="FuncionarioAtualizado"> Objeto funcionarioAtualizado com as novas informações</param>
        /// <returns> Um status code</returns>
        /// http://localhost:5000/api/funcionarios/2
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int IdFun, FuncionarioDomain FuncionarioAtualizado)
        {
            FuncionarioDomain FuncionarioBuscado = _FuncionarioRepository.BuscaPorId(IdFun);

            if (FuncionarioBuscado == null)
            {
                return NotFound
                 (
                    new
                    {
                        mensagem = "Funcionario não foi encontrado!!",
                        erro = true
                    }
                 );

            }

            try
            {
                _FuncionarioRepository.AtualizarIdUrl(IdFun, FuncionarioAtualizado);

                return NoContent();
            }
            catch (Exception codErro)
            {

                return BadRequest(codErro);
            }

        }

        /// <summary>
        /// Deleta um funcionario existente
        /// </summary>
        /// <param name="IdFun"> Id de funcionario que será deletado</param>
        /// <returns> Um status code 204 - No Content</returns>
        /// http://localhost:5000/api/funcionarios/3
        [HttpDelete("{id}")]
        public IActionResult Delete(int IdFun)
        {
            // Faz a chamada para o metodo Deletar()
            _FuncionarioRepository.Deletar(IdFun);

            // Retorna um status code 204 - No Content
            return StatusCode(204);
        }

    }
}
