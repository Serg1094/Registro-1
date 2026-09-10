using Core.feature.Commands;
using Core.feature.Queries;

using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpedientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpedientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<ExpedienteClinico>> Get([FromQuery] GetExpedientesQuery query)
        {
            
            return await _mediator.Send(query);
        }
               

        [HttpPost]
        public async Task<bool> Post([FromBody] AddExpedienteCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}