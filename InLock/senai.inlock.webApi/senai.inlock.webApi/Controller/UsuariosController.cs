using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi_.Domain;
using senai.inlock.webApi_.Interface;
using senai.inlock.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain UsuarioBuscado = _UsuarioRepository.Login(login.Email, login.Senha);

            if (UsuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválido!");
            }

            // define os dados que serão fornecidos no token - Payload
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email)
                ,new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString())
                ,new Claim(ClaimTypes.Role, UsuarioBuscado.IdTipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Inlock-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Inlock.webApi",
                audience: "Inlock.webApi",
                claims: claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

    }
}
