using Senai_01Filmes.Domains;

namespace Senai_01Filmes.Controllers
{
    internal interface IUsuarioRepository
    {
        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}