using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.feature.Commands
{
    public class AddTurnoCommand : IRequest<bool>
    {
        public long TurnoID { get; set; }
        public long? CitaID { get; set; }
        public long PacienteID { get; set; }
        public int SucursalID { get; set; }
        public string? NumeroTurno { get; set; }
        public DateOnly FechaTurno { get; set; }
        public int Prioridad { get; set; }
        public string? Estado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaLlamado { get; set; }
        public DateTime? FechaAtencion { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
    }

    public class AddTurnoCommandHandler : IRequestHandler<AddTurnoCommand, bool>
    {
        private readonly IGenericRepository<Turno> _TurnosRepositories;
        public AddTurnoCommandHandler(IGenericRepository<Turno> TurnosRepositories)
        {
            _TurnosRepositories = TurnosRepositories;
        }
        public async Task<bool> Handle(AddTurnoCommand request, CancellationToken cancellationToken)
        {
            Turno turno = new Turno();
            turno.TurnoID = request.TurnoID;
            turno.CitaID = request.CitaID;
            turno.PacienteID = request.PacienteID;
            turno.SucursalID = request.SucursalID;
            turno.NumeroTurno = request.NumeroTurno;
            turno.FechaTurno = request.FechaTurno;
            turno.Prioridad = request.Prioridad;
            turno.Estado = request.Estado;
            turno.FechaIngreso = request.FechaIngreso;
            turno.FechaLlamado = request.FechaLlamado;
            turno.FechaAtencion = request.FechaAtencion;
            turno.FechaFinalizacion = request.FechaFinalizacion;
            await _TurnosRepositories.AddAsync(turno);
            return true;
        }
    }
}
            
