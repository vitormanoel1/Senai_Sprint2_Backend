using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SPMedicalGroup_webApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdPaciente { get; set; }
        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public string NomePaciente { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public string Endereco { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
