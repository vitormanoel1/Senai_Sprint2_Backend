using SPMedicalGroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup_webApi.Interface
{
    interface IPacienteRepository
    {
        List<Paciente> ListarTodos();
        Paciente BuscarPorId(int id);
        void Cadastrar(Paciente novoPaciente);
        void Atualizar(int id, Paciente PacienteAtualizada);
        void Deletar(int id);
    }
}
