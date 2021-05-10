using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPMedicalGroup_webApi.Domains;
using SPMedicalGroup_webApi.Interface;
using SPMedicalGroup_webApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup_webApi.Controllers
{
    // define que o tipo de resposta da API será formato json
    [Produces("application/json")]
    // define que a rota de uma requisição será no formato dominio/api/nomeController
    //ex: http://localhost:5000/api/usuarios
    [Route("api/[controller]")]
    // define que é um controlador de API
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.ListarTodos());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_usuarioRepository.BuscarPorId(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {
            _usuarioRepository.Atualizar(id, usuarioAtualizado);
            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usuarioRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
