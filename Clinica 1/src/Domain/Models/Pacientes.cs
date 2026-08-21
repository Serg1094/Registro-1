using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Pacientes
    {
        public long PacienteID { get; set; }
        public string? CodigoPaciente { get; set; }
        public string? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public char? Sexo { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Telefono { get; set; }
        public string? TelefonoSecundario { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Pais { get; set; }
        public string? Ocupacion { get; set; }
        public string? TipoSangre { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
