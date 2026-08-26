using Core.Interfaces.Repositories;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.feature.Queries
{
    public class GetPacienteQuery : IRequest<List<Domain.Models.Pacientes>>
    {
        public int TotalRegistro { get; set; }
    }

    public class GetPacienteQueryHandler : IRequestHandler<GetPacienteQuery, List<Pacientes>>
    {
        private readonly IPacientes _pasientesrepositories;

        public GetPacienteQueryHandler(IPacientes pasientesrepositories)
        {
            _pasientesrepositories = pasientesrepositories;
        }

        public async Task<List<Pacientes>> Handle(GetPacienteQuery request, CancellationToken cancellationToken)
        {
            return request.TotalRegistro > 0 ? await _pasientesrepositories.GetPacientesAsync(request.TotalRegistro) : await _pasientesrepositories.GetPacientesAsync();
        }

    }
}