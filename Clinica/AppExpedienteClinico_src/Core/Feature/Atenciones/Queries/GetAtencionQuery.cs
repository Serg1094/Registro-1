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
    public class GetAtencionesQuery : IRequest<List<Domain.Models.Atenciones>>
    {
        public int TotalRegistro { get; set; }
    }

    public class GetAtencionesQueryHandler : IRequestHandler<GetAtencionesQuery, List<Atenciones>>
    {
        private readonly IAtenciones _atencionesRepository;

        public GetAtencionesQueryHandler(IAtenciones atencionesRepository)
        {
            _atencionesRepository = atencionesRepository;
        }

        public async Task<List<Atenciones>> Handle(GetAtencionesQuery request, CancellationToken cancellationToken)
        {
            return request.TotalRegistro > 0 ? await _atencionesRepository.GetAtencionesAsync(request.TotalRegistro) : await _atencionesRepository.GetAtencionesAsync();
        }
        
    }
}