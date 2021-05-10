using senai.inlock.webApi_.Domain;
using senai.inlock.webApi_.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
    private string StringConexao = "Data Source=LAPTOP-DSQUFTLB\\SQLEXPRESS; initial catalog=Inlock_Games_Tarde; user Id=sa; pwd=senai@132";

        public TipoUsuarioDomain BuscarPorId(int Id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryBuscarPorId = "select IdTipoUsuario, Titulo from TipoUsuarios where IdTipoUsuario = @Id";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscarPorId, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        TipoUsuarioDomain TipoUsuarioDomain = new TipoUsuarioDomain
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            Titulo = rdr["Titulo"].ToString()
                        };

                        return TipoUsuarioDomain;
                    }

                    else
                        return null;
                }
            }
        }

        public List<TipoUsuarioDomain> ListarTodos()
        {
            List<TipoUsuarioDomain> ListaTipoUsuario = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "select IdTipoUsuario, Titulo from TipoUsuarios";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain TipoUsuario = new TipoUsuarioDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            Titulo = rdr["Titulo"].ToString()
                        };

                        ListaTipoUsuario.Add(TipoUsuario);
                    }
                }
            }

            return ListaTipoUsuario;
        }
    }
}
