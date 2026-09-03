using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SignoVital
    {
        public long SignosVitalesID { get; set; }
        public long AtencionID { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public Decimal? PresionSistolica { get; set; }
        public Decimal? PresionDiastolica { get; set; }
        public Decimal? FrecuenciaCardiaca { get; set; }
        public Decimal? FrecuenciaRespiratoria { get; set; }
        public Decimal? Temperatura { get; set; }
        public Decimal? SaturacionOxigeno { get; set; }
        public Decimal? PesoKg { get; set; }
        public Decimal? TallaCm { get; set; }
        public Decimal? IMC { get; set; }
        public string? Observaciones { get; set; }
                
    }
}
