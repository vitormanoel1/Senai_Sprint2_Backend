using senai.inlock.webApi_.Domain;
using senai.inlock.webApi_.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string StringConexao = "Data Source=LAPTOP-DSQUFTLB\\SQLEXPRESS; initial catalog=Inlock_Games_Tarde; user Id=sa; pwd=senai@132";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="EstudioAtualizado"></param>
        public void Atualizar(int Id, EstudioDomain EstudioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateIdUrl = "Update Estudios set NomeEstudio = @Nome where IdEstudio = @Id";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Nome", EstudioAtualizado.NomeEstudio);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EstudioDomain BuscarPorId(int Id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "Select IdEstudio, NomeEstudio from Estudios where IdEstudio = @Id";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        EstudioDomain EstudioDomain = new EstudioDomain
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            NomeEstudio = rdr["NomeEstudio"].ToString()
                        };

                        return EstudioDomain;
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NovoEstudio"></param>
        public void Cadastrar(EstudioDomain NovoEstudio)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "insert into Estudios(NomeEstudio) values (@Nome)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", NovoEstudio.NomeEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        public void Deletar(int Id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "Delete from Estudios where IdEstudio = @Id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> ListarPorEstudio(int Id)
        {
            List<EstudioDomain> ListarPorEstudio = new List<EstudioDomain>();

            using (SqlConnection con =  new SqlConnection(StringConexao))
            {
                string querySelectPorEstudio = "select Estudios.NomeEstudio, nomeJogo from Estudios left join Jogos on Estudios.IdEstudio = Jogos.idEstudiog where Estudios.idJogos = @ID"; 

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectPorEstudio, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain
                        {
                            NomeEstudio = rdr["NomeEstudio"].ToString(),
                            Jogos = new JogosDomain
                            {
                                IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                                NomeJogo = rdr["NomeJogo"].ToString(),

                            }
                        };

                        ListarPorEstudio.Add(estudio);
                    }
                }
            }

            return ListarPorEstudio;
        }

        /// <summary>
        /// lista todos os estudios 
        /// </summary>
        /// <returns> uma lista de estudios</returns>
        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> ListaEstudio = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "Select IdEstudio, NomeEstudio from Estudios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain Estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr[0]),
                            NomeEstudio = rdr[1].ToString()
                        };

                        ListaEstudio.Add(Estudio);
                    }
                }
            }

            return ListaEstudio;
        }
    }
}
