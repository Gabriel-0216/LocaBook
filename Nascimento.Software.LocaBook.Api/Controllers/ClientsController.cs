using Domain.Commands.Requests;
using Domain.Queries.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Nascimento.Software.LocaBook.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("get-all-clients/skip/{skip:int}/take/{take:int}")]
        public async Task<IActionResult> GetAsync([FromHeader] bool includeLoans, [FromHeader] bool activeLoans,
            [FromRoute] int skip = 0, [FromRoute] int take = 0)
        {
            var getAllQuery = new GetAllClientsQuery(includeLoans, activeLoans, skip, take);
            var result = await _mediator.Send(getAllQuery);
            return Ok(result);
        }
        [HttpPost]
        [Route("insert-new-client")]
        public async Task<IActionResult> CreateAsync(CreateClientRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpPut]
        [Route("update-client")]
        public async Task<IActionResult> UpdateAsync(UpdateClientRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}