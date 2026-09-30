using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.feature.Commands
{
    public class AddCitasRangeCommand : IRequest<bool>
    {
        public List<Cita> Citas { get; set; } = new();
    }

    public class AddCitasRangeCommandHandler : IRequestHandler<AddCitasRangeCommand, bool>
    {
        private readonly IGenericRepository<Cita> _repo;

        public AddCitasRangeCommandHandler(IGenericRepository<Cita> repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(AddCitasRangeCommand request, CancellationToken cancellationToken)
        {
            await _repo.AddRangeAsync(request.Citas);
            return true;
        }
    }
}

