using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domain
{
    public class EstudioDomain
    {
        [Required(ErrorMessage = "Nome do estúdio é obrigatório!")]
        public int IdEstudio { get; set; }
        public string NomeEstudio { get; set; }
        public JogosDomain jogos { get; set; }
    }

}
