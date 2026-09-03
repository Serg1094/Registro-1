using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Alergia
    {
        public long AlergiaID { get; set; }
        public long PacienteID { get; set; }
        public string? TipoAlergia { get; set; }
        public string? Alergeno { get; set; }
        public string? Reaccion { get; set; }
        public string? Severidad { get; set; }
        public bool Activa { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
