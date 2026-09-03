using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("Antecedentes_Medicos")]
    public class AntecedenteMedico
    {
        public long AntecedenteMedicoID { get; set; }
        public long PacienteID { get; set; }
        public string TipoAntecedente { get; set; }
        public string? Descripcion { get; set; }
        public DateOnly? FechaReferencia { get; set; }
        public string? Observaciones { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
