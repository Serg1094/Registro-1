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
    public class AddPacientesCommand : IRequest<bool>
    {
        public long PacienteID { get; set; }
        public string? CodigoPaciente { get; set; }
        public string? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public char? Sexo { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Telefono { get; set; }
        public string? TelefonoSecundario { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Pais { get; set; }
        public string? Ocupacion { get; set; }
        public string? TipoSangre { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

    public class AddPacienteCommandHandler : IRequestHandler<AddPacientesCommand, bool>
    {
        private readonly IPacientes _pacientesrepositories;
        public AddPacienteCommandHandler(IPacientes pacientesrepositories)
        {
            _pacientesrepositories = pacientesrepositories;
        }

        public async Task<bool> Handle(AddPacientesCommand request, CancellationToken cancellationToken)
        {
            Pacientes paciente = new Pacientes();
            paciente.PacienteID = request.PacienteID;
            paciente.CodigoPaciente = request.CodigoPaciente;
            paciente.TipoDocumento = request.TipoDocumento;
            paciente.NumeroDocumento = request.NumeroDocumento;
            paciente.Nombres = request.Nombres;
            paciente.Apellidos = request.Apellidos;
            paciente.FechaNacimiento = request.FechaNacimiento;
            paciente.Sexo = request.Sexo;
            paciente.EstadoCivil = request.EstadoCivil;
            paciente.Telefono = request.Telefono;
            paciente.TelefonoSecundario = request.TelefonoSecundario;
            paciente.Email = request.Email;
            paciente.Direccion = request.Direccion;
            paciente.Ciudad = request.Ciudad;
            paciente.Pais = request.Pais;
            paciente.Ocupacion = request.Ocupacion;
            paciente.TipoSangre = request.TipoSangre;
            paciente.Activo = request.Activo;
            paciente.FechaRegistro = request.FechaRegistro;
            await _pacientesrepositories.AddPacientes(paciente);
            return true;
        }
    }
}


