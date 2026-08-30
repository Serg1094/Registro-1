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
    public class CitasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CitasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Atenciones>> Get([FromQuery] GetAtencionesQuery query)
        {
            //return await _citasRepository.GetCitasAsync();
            return await _mediator.Send(query);
        }

        //[HttpGet("{id}")]
        /*public async Task<Cita?> GetById(long id)
        {
            return await _citasRepository.GetCitaByIdAsync(id);
        }*/

        [HttpPost]
        public async Task<bool> Post([FromBody] AddAtencionCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}