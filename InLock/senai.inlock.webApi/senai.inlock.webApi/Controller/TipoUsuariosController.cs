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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }

        public TipoUsuariosController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository();
        }

         /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// http://localhost:5000/api/tipoUsuarios
        [HttpGet]
        public IActionResult Get()
        {
            List<TipoUsuarioDomain> ListaTipoUsuario = _TipoUsuarioRepository.ListarTodos();
            return Ok(ListaTipoUsuario);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            TipoUsuarioDomain TipoUsuario = _TipoUsuarioRepository.BuscarPorId(Id);

            if (TipoUsuario == null)
            {
                return NotFound("Nenhum TipoUsuario encontrado!");
            }

            return Ok(TipoUsuario);
        }
    }
}
