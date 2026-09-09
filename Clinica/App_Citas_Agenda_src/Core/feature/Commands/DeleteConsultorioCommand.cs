using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.feature.Commands
{
    public class DeleteConsultorioCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteConsultorioCommandHandler : IRequestHandler<DeleteConsultorioCommand, bool>
    {
        private readonly IGenericRepository<Consultorio> _repo;

        public DeleteConsultorioCommandHandler(IGenericRepository<Consultorio> repo) => _repo = repo;

        public async Task<bool> Handle(DeleteConsultorioCommand request, CancellationToken cancellationToken)
            => await _repo.DeleteAsync(request.Id);
    }
}