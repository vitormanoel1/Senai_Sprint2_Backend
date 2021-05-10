using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_01Filmes.Domains
{
    public class GeneroDomain
    {
        /// <summary>
        /// Classe que representa a entidade (tabela) Generos
        /// </summary>
        public int IdGenero { get; set; }

        [Required(ErrorMessage = " Esse campo é obrigatorio")]
        public string Nome { get; set; }
    }
}
