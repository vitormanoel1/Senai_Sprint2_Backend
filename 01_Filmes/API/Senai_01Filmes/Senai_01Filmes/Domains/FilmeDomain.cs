using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_01Filmes.Domains
{
    public class FilmeDomain
    {
        /// <summary>
        /// Classe que representa a entidade (tabela) Filmes
        /// </summary>
        public int IdFilme { get; set; }
        public string Titulo { get; set; }
        public int IdGenero { get; set; }
    }
}
