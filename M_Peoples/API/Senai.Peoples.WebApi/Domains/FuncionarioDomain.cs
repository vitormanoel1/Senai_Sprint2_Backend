using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class FuncionarioDomain
    {
        public int IdFuncionario { get; set; }

        [Required(ErrorMessage = "Nome do funcionario é obrigatorio")]
        public string NomeFuncio { get; set; }

        [Required(ErrorMessage = "Sobrenome do fuuncionario tambem é obrigatorio")]
        public string Sobrenome { get; set; }
    }
}
