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
    public class GetExpedientesQuery : IRequest<List<Domain.Models.ExpedienteClinico>>
    {
        public int TotalRegistro { get; set; }
    }

    public class GetExpedienteQueryHandler : IRequestHandler<GetExpedientesQuery, List<ExpedienteClinico>>
    {
        private readonly IExpedientes _expedientesRepository;

        public GetExpedienteQueryHandler(IExpedientes expedientesRepository)
        {
            _expedientesRepository = expedientesRepository;
        }

        public async Task<List<ExpedienteClinico>> Handle(GetExpedientesQuery request, CancellationToken cancellationToken)
        {
            return request.TotalRegistro > 0 ? await _expedientesRepository.GetExpedientesAsync(request.TotalRegistro) : await _expedientesRepository.GetExpedientesAsync();
        }

    }
}