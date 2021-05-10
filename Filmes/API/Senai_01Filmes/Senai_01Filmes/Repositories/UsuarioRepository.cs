using Senai_01Filmes.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_01Filmes.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório de usuários
    /// </summary>
    public class UsuarioRepository
    {
        // Define a string de conexão
        private string StringConexao = "Data Source=LAPTOP-DSQUFTLB\\SQLEXPRESS; initial catalog=Filmes; user Id=sa; pwd=senai@132";

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="Email">e-mail do usuário</param>
        /// <param name="Senha">senha do usuário</param>
        /// <returns>Um objeto do tipo UsuarioDomain que foi buscado</returns>
        public UsuarioDomain BuscarPorEmailSenha(string Email, string Senha)
        {
            // Define a conexão con passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Define a query a ser executada no banco de dados
                string querySelect = "SELECT IdUsuario, Email, Senha, Permissao FROM Usuarios WHERE Email = @Email AND Senha = @Senha;";

                // Define o comando passando a query e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // Define os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Senha", Senha);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando e armazena os dados no objeto rdr
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Caso dados tenham sido obtidos
                    if (rdr.Read())
                    {
                        // Cria um objeto usuarioBuscado
                        UsuarioDomain UsuarioBuscado = new UsuarioDomain
                        {
                            // Atribui às propriedades os valores das colunas
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            Permissao = rdr["Permissao"].ToString()
                        };

                        // Retorna o objeto usuarioBuscado
                        return UsuarioBuscado;
                    }

                    // Caso não encontre um e-mail e senha correspondentes, retorna null
                    return null;
                }
            }
        }
    }
}
