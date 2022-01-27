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
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("get-all-authors/{skip:int}/{take:int}")]
        public async Task<IActionResult> GetAsync([FromHeader] bool includeBooks, [FromRoute] int skip = 0, 
            [FromRoute] int take = 25)
        {
            var getAllAuthors = new GetAllAuthorsQuery(includeBooks, skip, take);
            var result = await _mediator.Send(getAllAuthors);
            return Ok(result);
        }
        [HttpPost]
        [Route("insert-author")]
        public async Task<IActionResult> CreateAuthorAsync([FromBody] CreateAuthorRequest authorRequest)
        {
            var result = await _mediator.Send(authorRequest);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpPut]
        [Route("edit-author")]
        public async Task<IActionResult> EditAuthorAsync([FromBody] UpdateAuthorRequest updateRequest)
        {
            var result = await _mediator.Send(updateRequest);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete]
        [Route("delete-author")]
        public async Task<IActionResult> DeleteAuthorAsync()
        {
            return BadRequest();
        }
        
    }
}
