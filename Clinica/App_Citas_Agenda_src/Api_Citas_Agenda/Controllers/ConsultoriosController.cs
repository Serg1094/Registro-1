using Core.feature.Commands;
using Core.feature.Queries;

using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsultoriosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsultoriosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Consultorio>> Get([FromQuery] GetConsultoriosQuery query)
        {
            return await _mediator.Send(query);
        }

        
        [HttpPost]
        public async Task<bool> Post([FromBody] AddConsultoriosCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}