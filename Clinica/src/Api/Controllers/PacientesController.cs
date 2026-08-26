using Core.feature.Commands;
using Core.feature.Queries;
using Core.Interfaces.Repositories;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PacientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Pacientes>> Get([FromQuery] GetPacienteQuery query)
        {
            return await _mediator.Send(query);
        }

        /*[HttpGet("{id}")]
        public async Task<Pacientes?> GetById(long id)
        {
            return await _pacientesRepository.GetPacienteByIdAsync(id);
        }*/

        [HttpPost]
        public async Task<bool> Post([FromBody] AddPacientesCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}