using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Medicos
    {
        public int MedicoID { get; set; }
        public int? UsuarioID { get; set; }
        public string? CodigoMedico { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? NumeroLicencia { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public bool Activo { get; set; }
    }
}
