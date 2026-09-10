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
    public class SignosVitalesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SignosVitalesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<SignoVital>> Get([FromQuery] GetSignosVitalesQuery query)
        {
            //return await _signosVitalesRepository.GetSignosVitalesAsync();
            return await _mediator.Send(query);
        }

        //[HttpGet("{id}")]
        /*public async Task<SignoVital?> GetById(long id)
        {
            return await _signosVitalesRepository.GetSignoVitalByIdAsync(id);
        }*/

        [HttpPost]
        public async Task<bool> Post([FromBody] AddSignosVitalesCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}