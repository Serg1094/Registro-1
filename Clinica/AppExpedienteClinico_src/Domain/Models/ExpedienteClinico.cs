using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ExpedienteClinico
    {
        public long ExpedienteID { get; set; }
        public long PacienteID { get; set; }
        public string? NumeroExpediente { get; set; }
        public DateTime FechaApertura { get; set; }
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
