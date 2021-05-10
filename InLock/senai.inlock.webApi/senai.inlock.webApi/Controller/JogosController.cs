using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domain;
using senai.inlock.webApi_.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogosRepository _JogoRepository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public JogosController()
        {
            _JogoRepository = new JogoRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// http://localhost:5000/api/jogos
        //[Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            List<JogosDomain> ListaJogos = _JogoRepository.ListarTodos();
            return Ok(ListaJogos);
        }

        [HttpGet]
        public IActionResult Get(int Id)
        {
            List<JogosDomain> ListaPorJogo = _JogoRepository.ListarTodos();

            return Ok(ListaPorJogo);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            JogosDomain Jogobuscado = _JogoRepository.BuscarPorId(Id);

            if (Jogobuscado == null)
            {
                return NotFound("Nenhum jogo foi encontrado!!");
            }

            return Ok(Jogobuscado);
        }

        [Authorize(Roles ="1")]
        [HttpPut("{Id}")]
        public IActionResult PutIdUrl(int Id, JogosDomain JogoAtualizado)
        {
            JogosDomain JogoBuscado = _JogoRepository.BuscarPorId(Id);

            if (JogoBuscado == null)
            {
                return NotFound
                    (
                       new
                       {
                           mensagem = "Jogo não encontrado!!",
                           erro = true
                       }
                    );
            }

            try
            {
                _JogoRepository.AtualizarIdUrl(Id, JogoAtualizado);
                return NoContent();
            }
            catch (Exception codErro)
            {

                return BadRequest(codErro);
            }
        }

        [Authorize(Roles ="1")]
        [HttpPost]
        public IActionResult Post(JogosDomain NovoJogo)
        {
            _JogoRepository.Cadastrar(NovoJogo);
            return StatusCode(201);
        }

        [Authorize(Roles ="1")]
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            _JogoRepository.Deletar(Id);
            return StatusCode(204);
        }

    }
}
