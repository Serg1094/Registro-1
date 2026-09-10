
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.feature.Queries
{
    public class GetSignosVitalesQuery : IRequest<List<Domain.Models.SignoVital>>
    {
        public int TotalRegistro { get; set; }
    }

    public class GetSignosVitalesQueryHandler : IRequestHandler<GetSignosVitalesQuery, List<SignoVital>>
    {
        private readonly IGenericRepository<SignoVital> _signosVitalesRepository;

        public GetSignosVitalesQueryHandler(IGenericRepository<SignoVital> signosVitalesRepository)
        {
            _signosVitalesRepository = signosVitalesRepository;
        }

        public async Task<List<SignoVital>> Handle(GetSignosVitalesQuery request, CancellationToken cancellationToken)
        {
            return request.TotalRegistro > 0 ? await _signosVitalesRepository.GetPageAsync(request.TotalRegistro) : await _signosVitalesRepository.GetAllAsync();
        }

    }
}