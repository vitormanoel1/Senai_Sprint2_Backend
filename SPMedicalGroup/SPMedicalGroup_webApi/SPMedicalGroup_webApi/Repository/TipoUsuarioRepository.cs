using SPMedicalGroup_webApi.Contexts;
using SPMedicalGroup_webApi.Domains;
using SPMedicalGroup_webApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup_webApi.Repository
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        // objeto contexto por onde serão chamados os métodos do EF Core
        projeto_medicalsContext ctx = new projeto_medicalsContext();

        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            if (tipoUsuarioAtualizado.TituloTipoUsuario != null)
            {
                tipoUsuarioBuscado.TituloTipoUsuario = tipoUsuarioAtualizado.TituloTipoUsuario;
            }

            ctx.TipoUsuarios.Update(tipoUsuarioBuscado);
            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(t => t.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);
            ctx.TipoUsuarios.Remove(tipoUsuarioBuscado);
            ctx.SaveChanges();
        }

        public List<TipoUsuario> ListarTodos()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
