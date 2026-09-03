using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.feature.Commands
{
    public class AddConsultoriosCommand : IRequest<bool>
    {
        public int ConsultorioID { get; set; }
        public int SucursalID { get; set; }
        public int? AreaID { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Piso { get; set; }
        public bool Activo { get; set; }
    }

    public class AddConsultoriosCommandHandler : IRequestHandler<AddConsultoriosCommand, bool>
    {
        private readonly IGenericRepository<Consultorio> _ConsultoriosRepositories;
        public AddConsultoriosCommandHandler(IGenericRepository<Consultorio> ConsultoriosRepositories)
        {
            _ConsultoriosRepositories = ConsultoriosRepositories;
        }
        public async Task<bool> Handle(AddConsultoriosCommand request, CancellationToken cancellationToken)
        {
            Consultorio consultorio = new Consultorio();
            consultorio.ConsultorioID = request.ConsultorioID;
            consultorio.SucursalID = request.SucursalID;
            consultorio.AreaID = request.AreaID;
            consultorio.Codigo = request.Codigo;
            consultorio.Nombre = request.Nombre;
            consultorio.Piso = request.Piso;
            consultorio.Activo = request.Activo;
            await _ConsultoriosRepositories.AddAsync(consultorio);
            return true;
        }
    }
}
            
