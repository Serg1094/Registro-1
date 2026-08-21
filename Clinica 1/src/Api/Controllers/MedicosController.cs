using Core.Interfaces.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicos _medicosRepository;

        public MedicosController(IMedicos medicosRepository)
        {
            _medicosRepository = medicosRepository;
        }

        [HttpGet]
        public async Task<List<Medicos>> Get()
        {
            return await _medicosRepository.GetMedicosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Medicos?> GetById(int id)
        {
            return await _medicosRepository.GetMedicoByIdAsync(id);
        }
    }
}