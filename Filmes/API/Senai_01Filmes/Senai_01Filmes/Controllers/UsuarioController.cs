using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai_01Filmes.Domains;
using Senai_01Filmes.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai_01Filmes.Controllers
{
    public class UsuarioController
    {
        // Define que o tipo de resposta da API será no formato JSON
        [Produces("application/json")]

        // Define que a rota de uma requisição será no formato dominio/api/nomeController
        // ex: http://localhost:5000/api/Usuarios
        [Route("api/[controller]")]

        // Define que é um controlador de API
        [ApiController]
        public class UsuariosController : ControllerBase
        {
            private UsuarioRepository _UsuarioRepository;

            /// <summary>
            /// Instancia o objeto _usuarioRepository para que haja a referência aos métodos no repositório
            /// </summary>
            public UsuariosController()
            {
                _UsuarioRepository = new UsuarioRepository();
            }

            /// <summary>
            /// Faz a autenticação do usuário
            /// </summary>
            /// <param name="Login">objeto com os dados de e-mail e senha</param>
            /// <returns>Um status code e, em caso de sucesso, os dados do usuário buscado</returns>
            [HttpPost("Login")]
            public IActionResult Login(UsuarioDomain Login)
            {
                // Busca o usuário pelo e-mail e senha
                UsuarioDomain UsuarioBuscado = _UsuarioRepository.BuscarPorEmailSenha(Login.Email, Login.Senha);

                // Caso não encontre nenhum usuário com o e-mail e senha informados
                if (UsuarioBuscado == null)
                {
                    // retorna NotFound com uma mensagem personalizada
                    return NotFound("E-mail ou senha inválidos!");
                }

                // Caso encontre, prossegue para a criação do token

                // Define os dados que serão fornecidos no token - Payload
                var claims = new[]
                {
                                         // TipoDaClaim, ValorDaClaim
                new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, UsuarioBuscado.Permissao),
                new Claim("Claim personalizada", "Valor teste")
            };

                // Define a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao"));

                // Define as credenciais do token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Define a composição do token
                var token = new JwtSecurityToken(
                    issuer: "Filmes.webApi",               // emissor do token
                    audience: "Filmes.webApi",             // destinatário do token
                    claims: claims,                        // dados definidos acima (linha 59)
                    expires: DateTime.Now.AddMinutes(30),  // tempo de expiração
                    signingCredentials: creds              // credenciais do token
                );

                // Retorna um status code 200 - Ok com o token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
        }
    }
}
