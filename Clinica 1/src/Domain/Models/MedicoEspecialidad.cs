using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Medico_Especialidad
    {
        public int MedicoID { get; set; }
        public int EspecialidadID { get; set; }
        public bool Principal { get; set; }
    }
}
