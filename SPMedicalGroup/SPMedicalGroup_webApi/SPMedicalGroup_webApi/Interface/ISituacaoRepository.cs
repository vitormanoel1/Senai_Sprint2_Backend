using SPMedicalGroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup_webApi.Interface
{
    interface ISituacaoRepository
    {
        List<Situacao> ListarTodos();
        Situacao BuscarPorId(int id);
        void Cadastrar(Situacao novaSituacao);
        void Atualizar(int id, Situacao situacaoAtualizada);
        void Deletar(int id);
    }
}
