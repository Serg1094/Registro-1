using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AtencionSintoma
    {
        public long AtencionSintomaID { get; set; }
        public long AtencionID { get; set; }
        public long SintomaID { get; set; }
        public string? Intensidad { get; set; }
        public int Duracion { get; set; }
        public string? Observaciones { get; set; }
        
    }
}
