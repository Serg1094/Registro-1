using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.feature.Queries
{
    public class GetConsultoriosQuery : IRequest<List<Domain.Models.Consultorio>>
    {
        public int TotalRegistro { get; set; }
    }

    public class GetConsultoriosQueryHandler : IRequestHandler<GetConsultoriosQuery, List<Consultorio>>
    {
        private readonly IGenericRepository<Consultorio> _consultoriosRepository;

        public GetConsultoriosQueryHandler(IGenericRepository<Consultorio> consultoriosRepository)
        {
            _consultoriosRepository = consultoriosRepository;
        }

        public async Task<List<Consultorio>> Handle(GetConsultoriosQuery request, CancellationToken cancellationToken)
        {
            return request.TotalRegistro > 0 ? await _consultoriosRepository.GetPageAsync(request.TotalRegistro) : await _consultoriosRepository.GetAllAsync();
        }

    }
}

