using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.feature.Commands
{
    public class DeleteTurnoCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteTurnoCommandHandler : IRequestHandler<DeleteTurnoCommand, bool>
    {
        private readonly IGenericRepository<Turno> _repo;

        public DeleteTurnoCommandHandler(IGenericRepository<Turno> repo) => _repo = repo;
        public async Task<bool> Handle(DeleteTurnoCommand request, CancellationToken cancellationToken)
            => await _repo.DeleteAsync(request.Id);
    }
}