using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SignoVital
    {
        public long SignoVitalID { get; set; }
        public long AtencionID { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int PresionSistolica { get; set; }
        public int PresionDiastolica { get; set; }
        public int FrecuenciaCardiaca { get; set; }
        public int FrecuenciaRespiratoria { get; set; }
        public int Temperatura { get; set; }
        public int SaturacionOxigeno { get; set; }
        public decimal PesoKm { get; set; }
        public decimal TallaCm { get; set; }
        public decimal? IMC { get; set; }
        public string? Observacion { get; set; }
                
    }
}
