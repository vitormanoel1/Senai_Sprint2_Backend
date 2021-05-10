using SPMedicalGroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup_webApi.Interface
{
    interface IEspecialidadeRepository
    {
        List<Especialidade> ListarTodos();
        Especialidade BuscarPorId(int id);
        void Cadastrar(Especialidade novaEspecialidade);
        void Atualizar(int id, Especialidade especialidadeAtualizada);
        void Deletar(int id);
    }
}
