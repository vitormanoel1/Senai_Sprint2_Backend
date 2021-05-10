using SPMedicalGroup_webApi.Contexts;
using SPMedicalGroup_webApi.Domains;
using SPMedicalGroup_webApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup_webApi.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        // objeto contexto por onde serão chamados os métodos do EF Core
        projeto_medicalsContext ctx = new projeto_medicalsContext();

        public void Atualizar(int id, Medico medicoAtualizada)
        {
            Medico medicoBuscado = ctx.Medicos.Find(id);

            if (medicoAtualizada.IdUsuario != null)
            {
                medicoBuscado.IdUsuario = medicoAtualizada.IdUsuario;
            }

            if (medicoAtualizada.IdEspecialidade != null)
            {
                medicoBuscado.IdEspecialidade = medicoAtualizada.IdEspecialidade;
            }

            if (medicoAtualizada.IdClinica != null)
            {
                medicoBuscado.IdClinica = medicoAtualizada.IdClinica;
            }

            if (medicoAtualizada.NomeMedico != null)
            {
                medicoBuscado.NomeMedico = medicoAtualizada.NomeMedico;
            }

            if (medicoAtualizada.Crm != null)
            {
                medicoBuscado.Crm = medicoAtualizada.Crm;
            }

            ctx.Medicos.Update(medicoBuscado);
            ctx.SaveChanges();
        }

        public Medico BuscarPorId(int id)
        {
            return ctx.Medicos.FirstOrDefault(m => m.IdMedico == id);
        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Medico medicoBuscado = ctx.Medicos.Find(id);
            ctx.Medicos.Remove(medicoBuscado);
            ctx.SaveChanges();
        }

        public List<Medico> ListarTodos()
        {
            return ctx.Medicos.ToList();
        }
    }
}
