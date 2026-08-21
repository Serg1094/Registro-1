using Core.Interfaces.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitasController : ControllerBase
    {
        private readonly ICitas _citasRepository;

        public CitasController(ICitas citasRepository)
        {
            _citasRepository = citasRepository;
        }

        [HttpGet]
        public async Task<List<Cita>> Get()
        {
            return await _citasRepository.GetCitasAsync();
        }

        [HttpGet("{id}")]
        public async Task<Cita?> GetById(long id)
        {
            return await _citasRepository.GetCitaByIdAsync(id);
        }
    }
}