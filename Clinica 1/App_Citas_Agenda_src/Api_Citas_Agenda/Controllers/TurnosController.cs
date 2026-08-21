using Core.Interfaces.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TurnosController : ControllerBase
    {
        private readonly ITurnos _turnosRepository;

        public TurnosController(ITurnos turnosRepository)
        {
            _turnosRepository = turnosRepository;
        }

        [HttpGet]
        public async Task<List<Turno>> Get()
        {
            return await _turnosRepository.GetTurnosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Turno?> GetById(long id)
        {
            return await _turnosRepository.GetTurnoByIdAsync(id);
        }
    }
}