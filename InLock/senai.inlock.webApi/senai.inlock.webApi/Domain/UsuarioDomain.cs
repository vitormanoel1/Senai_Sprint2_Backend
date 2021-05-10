using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domain
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }
        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "Email do usuário é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha do usuário é obrigatório!")]
        public string Senha { get; set; }
    }
}
