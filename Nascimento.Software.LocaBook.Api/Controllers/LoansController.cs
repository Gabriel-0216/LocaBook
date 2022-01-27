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
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoansController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("get-all-loans/skip/{skip:int}/take/{take:int}")]
        public async Task<IActionResult> GetLoansAsync([FromHeader] bool includeBooks, [FromHeader] bool includeClientDetails,
            [FromRoute] int skip = 0, [FromRoute] int take = 25)
        {
            var loanQuery = new GetAllLoansQuery(includeBooks, includeClientDetails, skip, take);
            var result = await _mediator.Send(loanQuery);
            return Ok(result);
        }
        [HttpGet]
        [Route("get-unfinished-loans/skip/{skip:int}/take/{take:int}")]
        public async Task<IActionResult> GetUnfinishedLoansAsync([FromHeader] bool includeBooks, 
            [FromHeader] bool includeClientDetails,
            [FromRoute] int skip = 0, [FromRoute] int take = 25)
        {
            var loanQuery = new GetUnfinishedLoanQuery(includeBooks, includeClientDetails, skip, take);
            var result = await _mediator.Send(loanQuery);
            return Ok(result);
        }

        [HttpGet]
        [Route("get-finished-loans/skip/{skip:int}/take/{take:int}")]
        public async Task<IActionResult> GetFinishedLoansAsync([FromHeader] bool includeBooks,
            [FromHeader] bool includeClientDetails,
            [FromRoute] int skip = 0, [FromRoute] int take = 25)
        {
            var loansQuery = new GetAllFinishedLoansQuery(includeBooks, includeClientDetails, skip, take);
            var result = await _mediator.Send(loansQuery);
            return Ok(result);
        }
        [HttpPost]
        [Route("insert-new-loan")]
        public async Task<IActionResult> CreateLoanAsync(CreateLoanRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPut]
        [Route("update-loan-status")]
        public async Task<IActionResult> UpdateLoanAsync(UpdateLoanRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}