using Core.Interfaces.Repositories;
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
        public long SignoVitalID { get; set; }
        public long AtencionID { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int PresionSistolica { get; set; }
        public int PresionDiastolica { get; set; }
        public int FrecuenciaCardiaca { get; set; }
        public int FrecuenciaRespiratoria { get; set; }
        public int Temperatura { get; set; }
        public int SaturacionOxigeno { get; set; }
        public decimal PesoKm { get; set; }
        public decimal TallaCm { get; set; }
        public decimal? IMC { get; set; }
        public string? Observacion { get; set; }
    }

    public class AddSignosVitalesCommandHandler : IRequestHandler<AddSignosVitalesCommand, bool>
    {
        private readonly ISignosVitales _signosVitalesRepositories;
        public AddSignosVitalesCommandHandler(ISignosVitales signosVitalesRepositories)
        {
            _signosVitalesRepositories = signosVitalesRepositories;
        }
        public async Task<bool> Handle(AddSignosVitalesCommand request, CancellationToken cancellationToken)
        {
            SignoVital signosVitales = new SignoVital();
            signosVitales.SignoVitalID = request.SignoVitalID;
            signosVitales.AtencionID = request.AtencionID;
            signosVitales.FechaRegistro = request.FechaRegistro;
            signosVitales.PresionSistolica = request.PresionSistolica;
            signosVitales.PresionDiastolica = request.PresionDiastolica;
            signosVitales.FrecuenciaCardiaca = request.FrecuenciaCardiaca;
            signosVitales.FrecuenciaRespiratoria = request.FrecuenciaRespiratoria;
            signosVitales.Temperatura = request.Temperatura;
            signosVitales.SaturacionOxigeno = request.SaturacionOxigeno;
            signosVitales.PesoKm = request.PesoKm;
            signosVitales.TallaCm = request.TallaCm;
            signosVitales.IMC = request.IMC;
            signosVitales.Observacion = request.Observacion;
            await _signosVitalesRepositories.AddSignoVital(signosVitales);
            return true;
        }
    }
}
