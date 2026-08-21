using Core.Interfaces.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsultoriosController : ControllerBase
    {
        private readonly IConsultorios _consultoriosRepository;

        public ConsultoriosController(IConsultorios consultoriosRepository)
        {
            _consultoriosRepository = consultoriosRepository;
        }

        [HttpGet]
        public async Task<List<Consultorio>> Get()
        {
            return await _consultoriosRepository.GetConsultoriosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Consultorio?> GetById(int id)
        {
            return await _consultoriosRepository.GetConsultorioByIdAsync(id);
        }
    }
}