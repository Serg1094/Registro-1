
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.feature.Queries
{
    public class GetDiagnosticosQuery : IRequest<List<Domain.Models.Diagnostico>>
    {
        public int TotalRegistro { get; set; }
    }

    public class GetDiagnosticosQueryHandler : IRequestHandler<GetDiagnosticosQuery, List<Diagnostico>>
    {
        private readonly IGenericRepository<Diagnostico> _diagnosticosRepository;

        public GetDiagnosticosQueryHandler(IGenericRepository<Diagnostico> diagnosticosRepository)
        {
            _diagnosticosRepository = diagnosticosRepository;
        }

        public async Task<List<Diagnostico>> Handle(GetDiagnosticosQuery request, CancellationToken cancellationToken)
        {
            return request.TotalRegistro > 0 ? await _diagnosticosRepository.GetPageAsync(request.TotalRegistro) : await _diagnosticosRepository.GetAllAsync();
        }

    }
}
