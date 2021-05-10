using SPMedicalGroup_webApi.Contexts;
using SPMedicalGroup_webApi.Domains;
using SPMedicalGroup_webApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup_webApi.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        // objeto contexto por onde serão chamados os métodos do EF Core
        projeto_medicalsContext ctx = new projeto_medicalsContext();

        public void Atualizar(int id, Paciente PacienteAtualizada)
        {
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);
            
            if (PacienteAtualizada.IdUsuario != null)
            {
                pacienteBuscado.IdUsuario = PacienteAtualizada.IdUsuario;
            }

            if (PacienteAtualizada.NomePaciente != null)
            {
                pacienteBuscado.NomePaciente = PacienteAtualizada.NomePaciente;
            }

            if (PacienteAtualizada.Rg != null)
            {
                pacienteBuscado.Rg = PacienteAtualizada.Rg;
            }

            if (PacienteAtualizada.Cpf != null)
            {
                pacienteBuscado.Cpf = PacienteAtualizada.Cpf;
            }

            if (PacienteAtualizada.Telefone != null)
            {
                pacienteBuscado.Telefone = PacienteAtualizada.Telefone;
            }

            if (PacienteAtualizada.Endereco != null)
            {
                pacienteBuscado.Endereco = PacienteAtualizada.Endereco;
            }

            ctx.Pacientes.Update(pacienteBuscado);
            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(int id)
        {
            return ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == id);
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Pacientes.Add(novoPaciente);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);
            ctx.Pacientes.Remove(pacienteBuscado);
            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return ctx.Pacientes.ToList();
        }
    }
}
