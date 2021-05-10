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
    //ex: http://localhost:5000/api/especialidades
    [Route("api/[controller]")]
    // define que é um controlador de API
    [ApiController]
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        // lista
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clinicaRepository.ListarTodos());
        }


        // busca pelo id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_clinicaRepository.BuscarPorId(id));
        }

        // cadastra
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Clinica novaClinica)
        {
            _clinicaRepository.Cadastrar(novaClinica);
            return StatusCode(201);
        }

        // atualiza
        [HttpPut("{id}")]
        public IActionResult Put(int id, Clinica clinicaAtualizada)
        {
            _clinicaRepository.Atualizar(id, clinicaAtualizada);
            return StatusCode(204);
        }

        //deleta
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clinicaRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
