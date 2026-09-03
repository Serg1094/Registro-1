using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Atenciones
    {
        public long AtencionID { get; set; }
        public long PacienteID { get; set; }
        public int MedicoID { get; set; }
        public long? CitaID { get; set; }
        public long ExpedienteID { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? MotivoConsulta { get; set; }
        public string? EnfermedadActual { get; set; }
        public string? ExploracionFisica { get; set; }
        public string? Observaciones { get; set; }
        public string? Estado { get; set; }
        public int? UsuarioCreacionID { get; set; }
        
    }
}
