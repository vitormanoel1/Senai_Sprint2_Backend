using senai.inlock.webApi_.Domain;
using senai.inlock.webApi_.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class JogoRepository : IJogosRepository
    {
        private string StringConexao = "Data Source=LAPTOP-DSQUFTLB\\SQLEXPRESS; initial catalog=Inlock_Games_Tarde; user Id=sa; pwd=senai@132";

        public void AtualizarIdUrl(int Id, JogosDomain JogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateIdUrl = "update Jogos set Jogos.IdEstudio = @IdEstudio, Jogos.NomeJogo = @NomeJogo, Jogos.Descricao = @Descricao, Jogos.DataLancamento = @DataLancamento, Jogos.Valor = @Valor where IdJogo = @Id";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@IdEstudio", JogoAtualizado.IdEstudio);
                    cmd.Parameters.AddWithValue("@NomeJogo", JogoAtualizado.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", JogoAtualizado.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", JogoAtualizado.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", JogoAtualizado.Valor);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogosDomain BuscarPorId(int Id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryBuscarPorId = "select IdJogo, NomeJogo, Descricao, DataLancamento, Valor from Jogos where Jogos.IdJogo = @Id";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscarPorId, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogosDomain JogosBuscado = new JogosDomain
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            NomeJogo = rdr["NomeJogo"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            Valor = Convert.ToDouble(rdr["Valor"])
                        };

                        return JogosBuscado;
                    }

                    return null; 
                }
            }
        }

        public void Cadastrar(JogosDomain NovoJogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "insert into Jogos(IdEstudio, NomeJogo, Descricao, DataLancamento, Valor) values (@IdEstudio, @Nome, @Descricao, @DataLancamento, @Valor)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", NovoJogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Nome", NovoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", NovoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", NovoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("Valor", NovoJogo.Valor);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int Id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "delete Jogos where Jogos.idJogo = @Id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogosDomain> ListarPorJogos(int Id)
        {
            List<JogosDomain> ListaPorJogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectJogos = "select IdJogo, NomeJogo, Descricao, DataLancamento, Valor, Jogos.IdEstudio, Estudios.IdEstudio, NomeEstudio from Jogos Inner Join Estudios on Jogos.IdEstudio = Estudios.IdEstudio where Jogos.IdEstudio = @Id";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectJogos, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogosDomain Jogos = new JogosDomain
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            NomeJogo = rdr["NomeJogo"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            Valor = Convert.ToDouble(rdr["Valor"]), 

                            Estudio = new EstudioDomain
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            }
                        };

                        ListaPorJogos.Add(Jogos);
                    }
                }
            }

            return ListaPorJogos;
        }

        public List<JogosDomain> ListarTodos()
        {
            List<JogosDomain> ListaJogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "Select IdJogo, IdEstudio, NomeJogo, Descricao, DataLancamento, Valor from Jogos";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogosDomain Jogo = new JogosDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr[0]),
                            IdEstudio = Convert.ToInt32(rdr[1]),
                            NomeJogo = rdr[2].ToString(), 
                            Descricao = rdr[3].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr[4]),
                            Valor = Convert.ToDouble(rdr[5])

                        };

                        ListaJogos.Add(Jogo);
                    }
                }
            }

            return ListaJogos;
        }
    }
}
