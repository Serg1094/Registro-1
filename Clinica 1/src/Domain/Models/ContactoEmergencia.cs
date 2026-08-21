using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Contacto_Emergencia
    {
        public long ContactoEmergenciaID { get; set; }
        public long PacienteID { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Parentesco { get; set; }
        public string? Telefono { get; set; }
        public string? TelefonoSecundario { get; set; }
        public string? Email { get; set; }
        public int Prioridad { get; set; }
        public bool Activo { get; set; }
    }
}
