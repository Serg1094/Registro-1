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
    public class AddDiagnosticoCommand : IRequest<bool>
    {
        public long DiagnosticoID { get; set; }
        public required string CodigoCIE10 { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
    }

    public class AddDiagnosticoCommandHandler : IRequestHandler<AddDiagnosticoCommand, bool>
    {
        private readonly IDiagnosticos _diagnosticosRepositories;
        public AddDiagnosticoCommandHandler(IDiagnosticos diagnosticosRepositories)
        {
            _diagnosticosRepositories = diagnosticosRepositories;
        }
        public async Task<bool> Handle(AddDiagnosticoCommand request, CancellationToken cancellationToken)
        {
            Diagnostico diagnosticos = new Diagnostico();
            diagnosticos.DiagnosticoID = request.DiagnosticoID;
            diagnosticos.CodigoCIE10 = request.CodigoCIE10;
            diagnosticos.Nombre = request.Nombre;
            diagnosticos.Descripcion = request.Descripcion;
            diagnosticos.Activo = request.Activo;
            await _diagnosticosRepositories.AddDiagnostico(diagnosticos);
            return true;
        }
    }
}