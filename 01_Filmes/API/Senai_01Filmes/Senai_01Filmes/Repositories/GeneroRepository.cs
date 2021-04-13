using Senai_01Filmes.Domains;
using Senai_01Filmes.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_01Filmes.Repositories
{

    /// <summary>
    /// Classe responsavel pelo repositório de gêneros
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexão que se concta com o bd e recebe os parametros
        /// Data Source = Nome do servidor
        /// initialcatalog = Nome do  banco de dados 
        /// user id = sa (Usuario)
        /// pwd = senai@132 (senha)
        /// tudo isso faz a autenticação do usuario sql server, passando o logon e senha
        /// integrated security=true = faz a autenticação do usuario do sistema (windows)
        /// </summary>
        private string StringConexao = "Data Source=LAPTOP-DSQUFTLB\\SQLEXPRESS; initial catalog=Filmes; user id=sa; pwd=senai@132";
        //private string StringConexao = "Data Source=LAPTOP-DSQUFTLB\\SQLEXPRESS; initial catalog=Filmes; integrated security=true";

        /// <summary>
        /// Atualiza um gênero passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto genero com as novas informações</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateIdBody = "UPDATE Generos SET Nome = @Nome WHERE idGenero = @Id";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    // Passa os valores para os parâmetros
                    cmd.Parameters.AddWithValue("@Id", genero.IdGenero);
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza um gênero passando o id pelo recurso (URL)
        /// </summary>
        /// <param name="IdGenero">id do gênero que será atualizado</param>
        /// <param name="genero">Objeto genero com as novas informações</param>
        public void AtualizarIdUrl(int IdGenero, GeneroDomain genero)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateIdUrl = "UPDATE Generos SET Nome = @Nome WHERE idGenero = @Id";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    // Passa os valores para os parâmetros
                    cmd.Parameters.AddWithValue("@Id", IdGenero);
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um gênero através do seu id
        /// </summary>
        /// <param name="id">id do gênero que será buscado</param>
        /// <returns>Um gênero buscado ou null caso não seja encontrado</returns>
        public GeneroDomain BuscarPorId(int IdGenero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = "SELECT idGenero, Nome FROM Generos WHERE idGenero = @Id";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para receber os valores do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@Id", IdGenero);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        // Se sim, instancia um novo objeto generoBuscado do tipo GeneroDomain
                        GeneroDomain GeneroBuscado = new GeneroDomain
                        {
                            // Atribui à propriedade idGenero o valor da coluna "idGenero" da tabela do banco de dados
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            // Atribui à propriedade nome o valor da coluna "Nome" da tabela do banco de dados
                            Nome = rdr["Nome"].ToString()
                        };

                        // Retorna o generoBuscado com os dados obtidos
                        return GeneroBuscado;
                    }

                    // Se não, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra umm novo genero
        /// </summary>
        /// <param name="NovoGenero"> Objeto NovoGenero com as informações que serão cadastradas </param>
        public void Cadastrar(GeneroDomain NovoGenero)
        {
            // Declara a conexão con passando a StringConexao como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Como não fazer
                // Declara a query que será executada
                    // INSERT INTO Generos(Nome) VALUES ('Ficção científica');
                    // INSERT INTO Generos(Nome) VALUES ('Joana D'Arc');
                    // INSERT INTO Generos(Nome) VALUES ('')DROP TABLE Filmes--
                // string queryInsert = "INSERT INTO Generos(Nome) VALUES ('" + NovoGenero.nome + "')";
                // Não usar dessa forma, pois pode causar o efeito Joana D'Arc
                // Além de permitir SQL Injection
                // Por exemplo
                // "Nome" : "Perdeu mané')DROP TABLE Filmes--"
                // Ao tentar cadastrar o comando acima, irá deletar a tabela Filmes do banco de dados
                // https://www.devmedia.com.br/sql-injection/6102


                // Declara a a query que será executada
                string queryInsert = "INSERT INTO Generos (Nome) VALUES (@Nome)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passsa o valor para o parâmetro @Nome
                    cmd.Parameters.AddWithValue("@Nome", NovoGenero.Nome);

                    // Abre a coonexão com o BD
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um Gênero existente pelo Id
        /// </summary>
        /// <param name="IdGenero"> Id do genero que será deletado</param>
        public void Deletar(int IdGenero)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query a ser executada passando o parâmetro @ID
                string queryDelete = "DELETE FROM Generos WHERE IdGenero = @Id";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Define o valor do id recebido no método como o valor do parâmetro @ID
                    cmd.Parameters.AddWithValue("@Id", IdGenero);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        ///  Lista todos os gêneros
        /// </summary>
        /// <returns> Uma lista de gêneros </returns>
        public List<GeneroDomain> ListarTodos()
        {
            // Cria uma lista ListarGenero onde serão armazenados os dados
            List<GeneroDomain> ListaGeneros = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                // Declara a instrução a ser executada
                string QuerySelectAll = "SELECT IdGenero, Nome FROM Generos";

                // Abre a conexão com o BD
                con.Open();

                // Declara a SqlDataReader rdr para percorrer a tabela do BD
                SqlDataReader rdr;

                // Declara a SqlCommand cmd passando a Query que será execuatada e a conexão com parâmetros
                using (SqlCommand cmd = new SqlCommand(QuerySelectAll, con))
                {
                    // Executa a Query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço irá se repetir
                    while (rdr.Read())
                    {
                        // Instancia um objeto genero do tipo GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            // Atribui à propriedade IdGenero o valor da primeira coluna da tabela do BD
                            IdGenero = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade Nome o valor da segunda coluna da tabela do BD
                            Nome = rdr[1].ToString()
                        };

                        // Adiciona o objeto genero à ListaGeneros
                        ListaGeneros.Add(genero);
                    }
                }
            }
            // Retorna uma lista de gêneros
            return ListaGeneros;
        }
    }
}
