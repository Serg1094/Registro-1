
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.feature.Commands
{
    public class AddCitasCommand : IRequest<bool>
    {
        public long CitaID { get; set; }
        public long PacienteID { get; set; }
        public int MedicoID { get; set; }
        public int? EspecialidadID { get; set; }
        public int? ConsultorioID { get; set; }
        public int EstadoCitaID { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime? FechaHoraFin { get; set; }
        public string? Motivo { get; set; }
        public string? Observaciones { get; set; }
        public int? UsuarioCreacionID { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public class AddCitasCommandHandler : IRequestHandler<AddCitasCommand, bool>
    {
        private readonly IGenericRepository<Cita> _CitasRepositories;
        public AddCitasCommandHandler(IGenericRepository<Cita> CitasRepositories)
        {
            _CitasRepositories = CitasRepositories;
        }
        public async Task<bool> Handle(AddCitasCommand request, CancellationToken cancellationToken)
        {
            Cita citas = new Cita();
            citas.CitaID = request.CitaID;
            citas.PacienteID = request.PacienteID;
            citas.MedicoID = request.MedicoID;
            citas.EspecialidadID = request.EspecialidadID;
            citas.ConsultorioID = request.ConsultorioID;
            citas.EstadoCitaID = request.EstadoCitaID;
            citas.FechaHoraInicio = request.FechaHoraInicio;
            citas.FechaHoraFin = request.FechaHoraFin;
            citas.Motivo = request.Motivo;
            citas.Observaciones = request.Observaciones;
            citas.UsuarioCreacionID = request.UsuarioCreacionID;
            citas.FechaCreacion = DateTime.Today;
            await _CitasRepositories.AddAsync(citas);
            return true;
        }
    }

}
