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
    //ex: http://localhost:5000/api/medicos
    [Route("api/[controller]")]
    // define que é um controlador de API
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository  _medicoRepository { get; set; }

        public MedicosController()
        {
            _medicoRepository = new MedicoRepository();
        }

        // listar
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_medicoRepository.ListarTodos());
        }

        // buscar por id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_medicoRepository.BuscarPorId(id));
        }

        // cadastro 
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Medico novoMedico)
        {
            _medicoRepository.Cadastrar(novoMedico);
            return StatusCode(201);
        }

        // atualiza
        [HttpPut]
        public IActionResult Put(int id, Medico medicoAtualizado)
        {
            _medicoRepository.Atualizar(id, medicoAtualizado);
            return StatusCode(204);
        }

        // deleta
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _medicoRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
