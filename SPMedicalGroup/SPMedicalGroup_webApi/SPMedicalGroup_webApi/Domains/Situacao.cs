using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SPMedicalGroup_webApi.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdSituacao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public string Situacao1 { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
