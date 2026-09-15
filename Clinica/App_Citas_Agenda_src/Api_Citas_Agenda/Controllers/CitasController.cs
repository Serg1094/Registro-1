using Core.Common;
using Core.feature.Commands;
using Core.feature.Queries;

using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Core.Common;

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
        public async Task<List<Cita>> Get([FromQuery] GetCitasQuery query)
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
        public async Task<bool> Post([FromBody] AddCitasCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("paged")]
        public async Task<PagedDto<List<Cita>>> GetPaged([FromQuery] GetCitasPagedQuery query)
        {
            return await _mediator.Send(query);
        }

    }
}   