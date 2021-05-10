using SPMedicalGroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup_webApi.Interface
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> ListarTodos();
        TipoUsuario BuscarPorId(int id);
        void Cadastrar(TipoUsuario novoTipoUsuario);
        void Atualizar(int id, TipoUsuario tipoUsuarioAtualizada);
        void Deletar(int id);
    }
}
