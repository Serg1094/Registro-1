
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.feature.Commands
{
    public class AddSignosVitalesCommand : IRequest<bool>
    {
        public long SignosVitalesID { get; set; }
        public long AtencionID { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public decimal? PresionSistolica { get; set; }
        public decimal? PresionDiastolica { get; set; }
        public decimal? FrecuenciaCardiaca { get; set; }
        public decimal? FrecuenciaRespiratoria { get; set; }
        public decimal? Temperatura { get; set; }
        public decimal? SaturacionOxigeno { get; set; }
        public decimal? PesoKg { get; set; }
        public decimal? TallaCm { get; set; }
        public decimal? IMC { get; set; }
        public string? Observaciones { get; set; }
    }

    public class AddSignosVitalesCommandHandler : IRequestHandler<AddSignosVitalesCommand, bool>
    {
        private readonly IGenericRepository<SignoVital> _signosVitalesRepositories;
        public AddSignosVitalesCommandHandler(IGenericRepository<SignoVital> signosVitalesRepositories)
        {
            _signosVitalesRepositories = signosVitalesRepositories;
        }
        public async Task<bool> Handle(AddSignosVitalesCommand request, CancellationToken cancellationToken)
        {
            SignoVital signosVitales = new SignoVital();
            signosVitales.SignosVitalesID = request.SignosVitalesID;
            signosVitales.AtencionID = request.AtencionID;
            signosVitales.FechaRegistro = request.FechaRegistro;
            signosVitales.PresionSistolica = request.PresionSistolica;
            signosVitales.PresionDiastolica = request.PresionDiastolica;
            signosVitales.FrecuenciaCardiaca = request.FrecuenciaCardiaca;
            signosVitales.FrecuenciaRespiratoria = request.FrecuenciaRespiratoria;
            signosVitales.Temperatura = request.Temperatura;
            signosVitales.SaturacionOxigeno = request.SaturacionOxigeno;
            signosVitales.PesoKg = request.PesoKg;
            signosVitales.TallaCm = request.TallaCm;
            signosVitales.IMC = request.IMC;
            signosVitales.Observaciones = request.Observaciones;
            await _signosVitalesRepositories.AddAsync(signosVitales);
            return true;
        }
    }
}
