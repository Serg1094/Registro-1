using Core.feature.Commands;
using Core.feature.Queries;

using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TurnosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TurnosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Turno>> Get([FromQuery] GetTurnosQuery query)
        {
            return await _mediator.Send(query);
        }

        
        [HttpPost]
        public async Task<bool> Post([FromBody] AddCitasCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}