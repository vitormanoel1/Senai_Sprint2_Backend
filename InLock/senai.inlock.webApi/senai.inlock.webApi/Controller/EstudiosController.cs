using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domain;
using senai.inlock.webApi_.Interface;
using senai.inlock.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Controller
{
    // define que o tipo de resposta da API será formato json
    [Produces("application/json")]

    // define que a rota de uma requisição será no formato dominio/api/nomeController
    [Route("api/[controller]")]

    // define que é um controlador de API
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        /// <summary>
        /// objeto _estudioRepository que irá receber todos os métodos definidos na interface IEstudioRepository
        /// </summary>
        private IEstudioRepository _EstudioRepository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EstudiosController()
        {
            _EstudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// http://localhost:5000/api/estudios
        [HttpGet]
        public IActionResult Get()
        {
            List<EstudioDomain> ListaEstudios = _EstudioRepository.ListarTodos();
            return Ok(ListaEstudios);
        }

        [HttpGet]
        public IActionResult Get(int Id)
        {
            List<EstudioDomain> ListaPorEstudio = _EstudioRepository.ListarTodos();

            return Ok(ListaPorEstudio);
        }

        [Authorize(Roles ="1")]
        [HttpPost]
        public IActionResult Post(EstudioDomain NovoEstudio)
        {
            _EstudioRepository.Cadastrar(NovoEstudio);
            return StatusCode(201);
        }

        [Authorize(Roles ="1")]
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int Id, EstudioDomain EstudioAtualizar)
        {
            EstudioDomain EstudioBuscado = _EstudioRepository.BuscarPorId(Id);

            if (EstudioBuscado == null)
            {
            return NotFound
                (
                   new
                   {
                       mensagem = "Estudio não encontrado!",
                       erro = true 
                   }
                );

            }

           try
              {
                _EstudioRepository.Atualizar(Id, EstudioAtualizar);
                return NoContent();
              }
              catch (Exception codErro)
              {
                return BadRequest(codErro);
              }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            EstudioDomain EstudioBuscado = _EstudioRepository.BuscarPorId(Id);

            if (EstudioBuscado == null)
            {
                return NotFound("Nenhum estudio foi encontrado!");
            }

            return Ok(EstudioBuscado);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _EstudioRepository.Deletar(Id);
            return StatusCode(204);
        }
    }
}
