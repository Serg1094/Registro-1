using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Habito
    {
        public long HabitoID { get; set; }
        public long PacienteID { get; set; }
        public string? TipoHabito { get; set; }
        public string? Descripcion { get; set; }
        public string? Frecuencia { get; set; }
        public bool Activo { get; set; }
    }
}
