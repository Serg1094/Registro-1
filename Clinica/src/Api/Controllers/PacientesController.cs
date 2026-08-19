using Core.Interfaces.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IPacientes _pacientesRepository;

        public PacientesController(IPacientes pacientesRepository)
        {
            _pacientesRepository = pacientesRepository;
        }

        [HttpGet]
        public async Task<List<Pacientes>> Get()
        {
            return await _pacientesRepository.GetPacientesAsync();
        }

        [HttpGet("{id}")]
        public async Task<Pacientes?> GetById(long id)
        {
            return await _pacientesRepository.GetPacienteByIdAsync(id);
        }
    }
}