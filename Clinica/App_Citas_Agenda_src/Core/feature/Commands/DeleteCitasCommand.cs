using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.feature.Commands
{
    public class DeleteCitaCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteCitaCommandHandler : IRequestHandler<DeleteCitaCommand, bool>
    {
        private readonly IGenericRepository<Cita> _repo;

        public DeleteCitaCommandHandler(IGenericRepository<Cita> repo) => _repo = repo;

        public async Task<bool> Handle(DeleteCitaCommand request, CancellationToken cancellationToken)
            => await _repo.DeleteAsync(request.Id);
    }
}
