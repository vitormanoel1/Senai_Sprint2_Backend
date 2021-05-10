using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SPMedicalGroup_webApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdClinica { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public TimeSpan HorarioAbertura { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public TimeSpan HorarioFechamento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public string RazaoSocial { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
