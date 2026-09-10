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
    public class DiagnosticosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiagnosticosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Diagnostico>> Get([FromQuery] GetDiagnosticosQuery query)
        {
            //return await _diagnosticosRepository.GetDiagnosticosAsync();
            return await _mediator.Send(query);
        }

        //[HttpGet("{id}")]
        /*public async Task<Diagnostico?> GetById(long id)
        {
            return await _diagnosticosRepository.GetDiagnosticoByIdAsync(id);
        }*/

        [HttpPost]
        public async Task<bool> Post([FromBody] AddDiagnosticoCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}