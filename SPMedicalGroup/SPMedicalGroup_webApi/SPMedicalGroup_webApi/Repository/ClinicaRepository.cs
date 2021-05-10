using SPMedicalGroup_webApi.Contexts;
using SPMedicalGroup_webApi.Domains;
using SPMedicalGroup_webApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup_webApi.Repository
{
    public class ClinicaRepository : IClinicaRepository
    {
        // objeto contexto por onde serão chamados os métodos do EF Core
        projeto_medicalsContext ctx = new projeto_medicalsContext();

        public void Atualizar(int id, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = ctx.Clinicas.Find(id);

            if (clinicaAtualizada.Cnpj != null)
            {
                clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;
            }

            if (clinicaAtualizada.HorarioAbertura != null)
            {
                clinicaBuscada.HorarioAbertura = clinicaAtualizada.HorarioAbertura;
            }

            if (clinicaAtualizada.HorarioFechamento != null)
            {
                clinicaBuscada.HorarioFechamento = clinicaAtualizada.HorarioFechamento;
            }

            if (clinicaAtualizada.Endereco != null)
            {
                clinicaBuscada.Endereco = clinicaAtualizada.Endereco;
            }

            if (clinicaAtualizada.NomeFantasia != null)
            {
                clinicaBuscada.NomeFantasia = clinicaAtualizada.NomeFantasia;
            }

            ctx.Clinicas.Update(clinicaBuscada);
            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int id)
        {
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == id);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Clinica clinicaBuscada = ctx.Clinicas.Find(id);
            ctx.Clinicas.Remove(clinicaBuscada);
            ctx.SaveChanges();
        }

        public List<Clinica> ListarTodos()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
