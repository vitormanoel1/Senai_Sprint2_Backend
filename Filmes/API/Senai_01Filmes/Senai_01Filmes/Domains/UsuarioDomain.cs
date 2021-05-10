using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_01Filmes.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        /// <summary>
        /// Define que o campo é obrigatório
        /// </summary>
        [Required(ErrorMessage = "Email é Obrigatório")]
        public string Email { get; set; }

        /// <summary>
        /// Define que o cmapo é obrigatório e precisa ter no minimo 6 caracter e o maximo de 20
        /// </summary>
        [Required(ErrorMessage = "Senha Obrigatória")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = " O campo Senha requer no minimo 6 caracter")]
        public string Senha { get; set; }

        public string Permissao{ get; set; }
    }
}
