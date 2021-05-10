using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SPMedicalGroup_webApi.Contexts;
using SPMedicalGroup_webApi.Domains;
using SPMedicalGroup_webApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup_webApi.Repository
{
    public class ConsultaRepository : IConsultaRepository
    {
        // objeto contexto por onde serão chamados os métodos do EF Core
        projeto_medicalsContext ctx = new projeto_medicalsContext();

        public void Atualizar(int id, Consulta consultaAtualizada)
        {
            Consulta consultaBuscada = ctx.Consulta.Find(id);

            if (consultaAtualizada.IdMedico != null)
            {
               consultaBuscada.IdMedico = consultaAtualizada.IdMedico;
            }

            if (consultaAtualizada.IdPaciente != null)
            {
                consultaBuscada.IdPaciente = consultaAtualizada.IdPaciente;
            }

            if (consultaAtualizada.IdSituacao != null)
            {
                consultaBuscada.IdSituacao = consultaAtualizada.IdSituacao;
            }

            if (consultaAtualizada.DataConsulta != null)
            {
                consultaBuscada.DataConsulta = consultaAtualizada.DataConsulta;
            }

            if (consultaAtualizada.Descricao != null)
            {
                consultaBuscada.Descricao = consultaAtualizada.Descricao;
            }

            ctx.Consulta.Update(consultaBuscada);
            ctx.SaveChanges();
        }

        public Consulta BuscarPorId(int id)
        {
            return ctx.Consulta.FirstOrDefault(c => c.IdConsulta == id);
        }

        [Authorize(Roles = "1")]
        public void Cadastrar(Consulta novaConsulta)
        {
            ctx.Consulta.Add(novaConsulta);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Consulta consultaBuscada = ctx.Consulta.Find(id);
            ctx.Consulta.Remove(consultaBuscada);
            ctx.SaveChanges();
        }

        public List<Consulta> ListarConsultas()
        {
            return ctx.Consulta.Include(c => c.IdMedicoNavigation).Include(c => c.IdPacienteNavigation).Include(c => c.IdSituacaoNavigation)
                .Select(c => new Consulta()
                {
                    Descricao = c.Descricao,
                    DataConsulta = c.DataConsulta,

                    IdMedicoNavigation = new Medico() 
                    { 
                        IdMedico = c.IdMedicoNavigation.IdMedico,
                        NomeMedico = c.IdMedicoNavigation.NomeMedico,
                        IdEspecialidade = c.IdMedicoNavigation.IdEspecialidade,
                        IdClinica = c.IdMedicoNavigation.IdClinica
                    },

                    IdPacienteNavigation = new Paciente() 
                    { 
                        IdPaciente = c.IdPacienteNavigation.IdPaciente,
                        NomePaciente = c.IdPacienteNavigation.NomePaciente,
                        DataNascimento = c.IdPacienteNavigation.DataNascimento,
                        Rg = c.IdPacienteNavigation.Rg,
                        Cpf = c.IdPacienteNavigation.Cpf,
                        Endereco = c.IdPacienteNavigation.Endereco
                    }, 

                    IdSituacaoNavigation = new Situacao() 
                    { 
                        IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                        Situacao1 = c.IdSituacaoNavigation.Situacao1
                    }

                }).ToList();
        }

        public List<Consulta> ListarTodos()
        {
            return ctx.Consulta.ToList();
        }
    }
}
