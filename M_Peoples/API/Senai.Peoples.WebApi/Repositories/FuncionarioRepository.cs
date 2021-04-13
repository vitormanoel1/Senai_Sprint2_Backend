using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos funcionarios
    /// </summary>
    public class FuncionarioRepository : IFuncionarioRepository
    {
        // <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source = Nome do servidor
        /// Initial catalog = Nome do banco de dados
        /// User Id=sa; pwd=senai@132 = Faz a autenticação com o usuário do SQL Server, passando o logon e a senha
        /// </summary>
        private string StringConexao = "Data Source=LAPTOP-DSQUFTLB\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=senai@132";

        /// <summary>
        /// Atualiza um funcionario passando o id pelo recurso (URL)
        /// </summary>
        /// <param name="IdFun"> Id do funcionario que será atualizado</param>
        /// <param name="Funcionario"> Objeto funcionario com as novas informações</param>
        public void AtualizarIdUrl(int IdFun, FuncionarioDomain Funcionario)
        {
            // Declara a SqlConnection con passado a string de conexão como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateIdUrl = "UPDATE Funcionarios SET NomeFuncio = @Nome where IdFuncionario = @Id";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parametro
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    // Passa o valor para o parametro @ID
                    cmd.Parameters.AddWithValue("@Id", IdFun);

                    // Passa o valor para o parametro @Id
                    cmd.Parameters.AddWithValue("@Nome", Funcionario.NomeFuncio);

                    // Abre a conexão com o banco
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um funcionario através do seu id
        /// </summary>
        /// <param name="IdFun"> Id do funcionario que será buscado</param>
        /// <returns> Um funcionario buscado ou null caso não seja encontrado</returns>
        public FuncionarioDomain BuscaPorId(int IdFun)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = "SELECT IdFuncionario, NomeFuncio, sobrenome FROM Funcionarios WHERE IdFuncionario = @Id";

                // Abre a conexão com o BD
                con.Open();

                // Declara o SqlDataReader rdr para receber os valores do banco
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parametros
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor para o parametro @ID
                    cmd.Parameters.AddWithValue("@Id", IdFun);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Verifica se o resultado da query retornou algum registro 
                    if (rdr.Read())
                    {
                        // Se sim, instancia um novo objeto funcionarioBuscado do tipo FuncionarioDomain
                        FuncionarioDomain FuncionarioBuscado = new FuncionarioDomain
                        {
                            // Atribui à propriedade idFuncionario o valor da coluna "idFuncionario" da tabela do banco
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),

                            // Atribui à propriedade nome o valor da coluna "NomeFuncio" da tabela do banco 
                            NomeFuncio = rdr["NomeFuncio"].ToString(),

                            // Atribui à propriedade sobrenome o valor da coluna "SobrenomeFuncio" da tabela do banco
                            Sobrenome = rdr["Sobrenome"].ToString(),
                        };

                        // Retorna o funcionarioBuscado com os dados obtidos
                        return FuncionarioBuscado;
                    }

                    // Se não, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo funcionario
        /// </summary>
        /// <param name="NovoFuncionario"> Objeto novoFuncionario com as informações que serão cadastradas</param>
        public void Cadastrar(FuncionarioDomain NovoFuncionario)
        {
            // Declara a conexão con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "INSERT INTO Funcionarios VALUES (@NomeFuncio, @Sobrenome)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor para o parâmetro @Nome
                    cmd.Parameters.AddWithValue("@NomeFuncio", NovoFuncionario.NomeFuncio);
                    cmd.Parameters.AddWithValue("@Sobrenome", NovoFuncionario.Sobrenome);

                    // Abre a conexão com o banco
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um funcionario através do seu id 
        /// </summary>
        /// <param name="IdFun"> Id do funcionario que será deletado</param>
        public void Deletar(int IdFun)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara q query a ser executada passando o parâmetro
                string queryDelete = "DELETE FROM Funcionarios WHERE IdFuncionario = @Id";

                // Declara a SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Define o valor do id recebido no método como o valor do parâmetro @ID
                    cmd.Parameters.AddWithValue("@Id", IdFun);

                    // Abre a conexão com o banco
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os funcionarios 
        /// </summary>
        /// <returns> Uma lista</returns>
        public List<FuncionarioDomain> ListarTodos()
        {
            List<FuncionarioDomain> ListaFuncionario = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdFuncionario, NomeFuncio, sobrenome FROM Funcionarios";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        FuncionarioDomain Funcionario = new FuncionarioDomain()
                        {
                            // Atribui à propriedade idFuncionario o valor da primeira coluna da tabela do banco de dados
                            IdFuncionario = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade nome o valor da segunda coluna da tabela do banco de dados
                            NomeFuncio = rdr[1].ToString(),

                            // Atribui à propriedade sobrenome o valor da terceira coluna da tabela do banco de dados
                            Sobrenome = rdr[2].ToString()
                        };

                        // Adiciona o objeto funcionario  criado á listaFuncionario
                        ListaFuncionario.Add(Funcionario);
                    }
                }
            }

            // Retorna a lista de funcionario
            return ListaFuncionario;
        }
    }
}