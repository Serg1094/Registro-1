using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Turno
    {
        public long TurnoID { get; set; }
        public long? CitaID { get; set; }
        public long PacienteID { get; set; }
        public int SucursalID { get; set; }
        public string? NumeroTurno { get; set; }
        public DateOnly FechaTurno { get; set; }
        public int Prioridad { get; set; }
        public string? Estado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaLlamado { get; set; }
        public DateTime? FechaAtencion { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
    }
}
