using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.feature.Queries
{
    public class GetTurnosQuery : IRequest<List<Domain.Models.Turno>>
    {
        public int TotalRegistro { get; set; }
    }

    public class GetTurnosQueryHandler : IRequestHandler<GetTurnosQuery, List<Turno>>
    {
        private readonly IGenericRepository<Turno> _turnosRepository;

        public GetTurnosQueryHandler(IGenericRepository<Turno> turnosRepository)
        {
            _turnosRepository = turnosRepository;
        }

        public async Task<List<Turno>> Handle(GetTurnosQuery request, CancellationToken cancellationToken)
        {
            return request.TotalRegistro > 0 ? await _turnosRepository.GetPageAsync(request.TotalRegistro) : await _turnosRepository.GetAllAsync();
        }

    }
}