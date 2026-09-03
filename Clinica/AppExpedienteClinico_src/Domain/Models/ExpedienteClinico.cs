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
        public DateOnly FechaApertura { get; set; }
        public string? Observaciones { get; set; }
        public bool Activo { get; set; }
    }
}
