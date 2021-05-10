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
    public class EspecialidadesController : ControllerBase
    {
        private IEspecialidadeRepository _especialidadeRepository { get; set; }

        public EspecialidadesController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        public IActionResult Get()
        {
            return Ok(_especialidadeRepository.ListarTodos());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_especialidadeRepository.BuscarPorId(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Especialidade novaEspecialidade)
        {
            _especialidadeRepository.Cadastrar(novaEspecialidade);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Especialidade especialidadeAtualizada)
        {
            _especialidadeRepository.Atualizar(id, especialidadeAtualizada);
            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _especialidadeRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
