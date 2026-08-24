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
    public class GetCitasQuery : IRequest<List<Domain.Models.Cita>>
    {
        public int TotalRegistro { get; set; }
    }

    public class GetCitasQueryHandler : IRequestHandler<GetCitasQuery, List<Cita>>
    {
        private readonly ICitas _citasRepository;

        public GetCitasQueryHandler(ICitas citasRepository)
        {
            _citasRepository = citasRepository;
        }

        public async Task<List<Cita>> Handle(GetCitasQuery request, CancellationToken cancellationToken)
        {
            return request.TotalRegistro > 0 ? await _citasRepository.GetCitasAsync(request.TotalRegistro) : await _citasRepository.GetCitasAsync();
        }
                
    }
}
