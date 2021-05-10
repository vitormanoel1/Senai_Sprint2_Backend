using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SPMedicalGroup_webApi.Domains
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdEspecialidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public string NomeEspecialidade { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
