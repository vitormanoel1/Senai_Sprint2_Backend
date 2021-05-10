using SPMedicalGroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup_webApi.Interface
{
    interface IMedicoRepository
    {
        List<Medico> ListarTodos();
        Medico BuscarPorId(int id);
        void Cadastrar(Medico novoMedico);
        void Atualizar(int id, Medico medicoAtualizada);
        void Deletar(int id);
    }
}
