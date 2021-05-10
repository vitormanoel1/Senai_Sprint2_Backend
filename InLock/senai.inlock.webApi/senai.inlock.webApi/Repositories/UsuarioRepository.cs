using senai.inlock.webApi_.Domain;
using senai.inlock.webApi_.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source=LAPTOP-DSQUFTLB\\SQLEXPRESS; initial catalog=Inlock_Games_Tarde; user Id=sa; pwd=senai@132";

        public UsuarioDomain Login(string Email, string Senha)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

            string querySelect = "select * from Usuario where Email = @Email and Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Senha", Senha);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain UsuarioBuscado = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString()
                        };

                        return UsuarioBuscado;
                    }

                    return null;
                }
            }
        }
    }
}
