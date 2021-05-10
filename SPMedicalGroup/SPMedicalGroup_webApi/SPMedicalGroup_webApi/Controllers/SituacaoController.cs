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
    //ex: http://localhost:5000/api/situacao
    [Route("api/[controller]")]
    // define que é um controlador de API
    [ApiController]
    public class SituacaoController : ControllerBase
    {
        private ISituacaoRepository _situacaoRepository { get; set; }

        public SituacaoController()
        {
            _situacaoRepository = new SituacaoRepository();
        }

        // lista
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_situacaoRepository.ListarTodos());
        }

        // busca pelo id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_situacaoRepository.BuscarPorId(id));
        }

        // cadastra
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Situacao novaSituacao)
        {
            _situacaoRepository.Cadastrar(novaSituacao);
            return StatusCode(201);
        }

        // atualiza
        [HttpPut("{id}")]
        public IActionResult Put(int id, Situacao situacaoAtualizado)
        {
            _situacaoRepository.Atualizar(id, situacaoAtualizado);
            return StatusCode(204);
        }

        //deleta
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _situacaoRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
