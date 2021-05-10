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
    //ex: http://localhost:5000/api/consultas
    [Route("api/[controller]")]
    // define que é um controlador de API
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        // lista
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_consultaRepository.ListarTodos());
        }

        [HttpGet("Lista")]
        public IActionResult GetConsulta()
        {
            return Ok(_consultaRepository.ListarConsultas());
        }

        // busca pelo id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_consultaRepository.BuscarPorId(id));
        }

        // cadastra
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Consulta novaConsulta)
        {
            _consultaRepository.Cadastrar(novaConsulta);
            return StatusCode(201);
        }

        // atualiza
        [HttpPut("{id}")]
        public IActionResult Put(int id, Consulta consultaAtualizado)
        {
           _consultaRepository.Atualizar(id, consultaAtualizado);
            return StatusCode(204);
        }

        //deleta
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _consultaRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
