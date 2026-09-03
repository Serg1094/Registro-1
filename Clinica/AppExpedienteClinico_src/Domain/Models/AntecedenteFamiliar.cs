using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AntecedenteFamiliar
    {
        public long AntecedenteFamiliarID { get; set; }
        public long PacienteID { get; set; }
        public string? Parentesco { get; set; }
        public string? Enfermedad { get; set; }
        public string?  Observaciones { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
