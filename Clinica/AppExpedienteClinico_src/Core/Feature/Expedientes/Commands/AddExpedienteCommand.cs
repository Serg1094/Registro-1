using Core.Interfaces.Repositories;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.feature.Commands
{
    public class AddExpedienteCommand : IRequest<bool>
    {
        public long ExpedienteID { get; set; }
        public long PacienteID { get; set; }
        public string? NumeroExpediente { get; set; }
        public DateTime FechaApertura { get; set; }
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
    }

    public class AddExpedienteCommandHandler : IRequestHandler<AddExpedienteCommand, bool>
    {
        private readonly IExpedientes _expedientesRepositories;
        public AddExpedienteCommandHandler(IExpedientes expedientesRepositories)
        {
            _expedientesRepositories = expedientesRepositories;
        }
        public async Task<bool> Handle(AddExpedienteCommand request, CancellationToken cancellationToken)
        {
            ExpedienteClinico expedientes = new ExpedienteClinico();
            expedientes.ExpedienteID = request.ExpedienteID;
            expedientes.PacienteID = request.PacienteID;
            expedientes.NumeroExpediente = request.NumeroExpediente;
            expedientes.FechaApertura = request.FechaApertura;
            expedientes.Descripcion = request.Descripcion;
            expedientes.Activo = request.Activo;
            await _expedientesRepositories.AddExpediente(expedientes);
            return true;
        }
    }
}
            