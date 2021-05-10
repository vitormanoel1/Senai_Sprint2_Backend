using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domain
{
    public class JogosDomain
    {
        public int IdJogo { get; set; }
        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "Nome do jogo é obrigatório!")]
        public string NomeJogo { get; set; }
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Data de lançamento do jogo é obrigatório!")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "Valor do jogo é obrigatório!")]
        public double Valor { get; set; }

        public EstudioDomain Estudio { get; set; }
    }
}
