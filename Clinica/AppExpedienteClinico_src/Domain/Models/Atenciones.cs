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
        public long MedicoID { get; set; }
        public long CitaID { get; set; }
        public long ExpedienteID { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string MotivoConsulta { get; set; }
        public string? EnfermedadActual { get; set; }
        public string? ExploracionFisica { get; set; }
        public string? Observaciones { get; set; }
        public bool Estado { get; set; }
        public long UsuarioCreacionID { get; set; }
        
    }
}
