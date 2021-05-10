using Senai_01Filmes.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_01Filmes.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repoistório UsuarioRepository
    /// </summary>
    interface IUsuarioRepositorycs
    {
        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="Email">e-mail do usuário</param>
        /// <param name="Senha">senha do usuário</param>
        /// <returns>Um objeto do tipo UsuarioDomain que foi buscado</returns>
        UsuarioDomain BuscarPorEmailSenha(string Email, string Senha);
    }
}
