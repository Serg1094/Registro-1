using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AtencionDiagnostico
    {
        public long AtencionDiagnosticoID { get; set; }
        public long AtencionID { get; set; }
        public int DiagnosticoID { get; set; }
        public string? TipoDiagnostico { get; set; }
        public string? Observaciones { get; set; }
    }
}
