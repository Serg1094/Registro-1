using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Core.Interfaces.Repositories;

namespace Core.feature.Commands
{
    public class AddAtencionCommand : IRequest<bool>
    {
        public long AtencionID { get; set; }
        public long PacienteID { get; set; }
        public long MedicoID { get; set; }
        public long CitaID { get; set; }
        public long ExpedienteID { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public required string MotivoConsulta { get; set; }
        public string? EnfermedadActual { get; set; }
        public string? ExploracionFisica { get; set; }
        public string? Observaciones { get; set; }
        public bool Estado { get; set; }
        public long UsuarioCreacionID { get; set; }
    }

    public class AddAtencionCommandHandler : IRequestHandler<AddAtencionCommand, bool>
    {
        private readonly IAtenciones _AtencionesRepositories;
        public AddAtencionCommandHandler(IAtenciones AtencionesRepositories)
        {
            _AtencionesRepositories = AtencionesRepositories;
        }
        public async Task<bool> Handle(AddAtencionCommand request, CancellationToken cancellationToken)
        {
            Atenciones atencion = new Atenciones();
            atencion.AtencionID = request.AtencionID;
            atencion.PacienteID = request.PacienteID;
            atencion.MedicoID = request.MedicoID;
            atencion.CitaID = request.CitaID;
            atencion.ExpedienteID = request.ExpedienteID;
            atencion.FechaInicio = request.FechaInicio;
            atencion.FechaFin = request.FechaFin;
            atencion.MotivoConsulta = request.MotivoConsulta;
            atencion.EnfermedadActual = request.EnfermedadActual;
            atencion.ExploracionFisica = request.ExploracionFisica;
            atencion.Observaciones = request.Observaciones;
            atencion.Estado = request.Estado;
            atencion.UsuarioCreacionID = request.UsuarioCreacionID;
            await _AtencionesRepositories.AddAtenciones(atencion);
            return true;
        }
    }
}
