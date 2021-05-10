using SPMedicalGroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup_webApi.Interface
{
    interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);
        List<Usuario> ListarTodos();
        void Cadastrar(Usuario novoUsuario);
        void Deletar(int id);
        void Atualizar(int id, Usuario usuarioAtualizado);
        Usuario BuscarPorId(int id);
    }
}
