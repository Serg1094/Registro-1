using Core.Common;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.feature.Queries
{
    public class GetCitasPagedQuery : IRequest<PagedDto<List<Cita>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Filtro { get; set; }
    }

    public class GetCitasPagedQueryHandler : IRequestHandler<GetCitasPagedQuery, PagedDto<List<Cita>>>
    {
        private readonly IGenericRepository<Cita> _citasRepository;

        public GetCitasPagedQueryHandler(IGenericRepository<Cita> citasRepository)
        {
            _citasRepository = citasRepository;
        }

        public async Task<PagedDto<List<Cita>>> Handle(GetCitasPagedQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Cita, bool>>? filtro = !string.IsNullOrEmpty(request.Filtro)
                ? Filter.FromStringExpression<Cita>(request.Filtro)
                : null;

            var resultado = await _citasRepository.GetPagedAsync(
                request.PageNumber,
                request.PageSize,
                filtro);

            return new PagedDto<List<Cita>>(
                resultado.TotalRecords,
                resultado.CurrentPage,
                resultado.PageSize,
                resultado.Data);
        }
    }
}
