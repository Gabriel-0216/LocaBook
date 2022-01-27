using Domain.Commands.Requests;
using Domain.Queries.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Nascimento.Software.LocaBook.Api.Controllers
{   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("get-all-books/skip/{skip:int}/take/{take:int}/")]
        public async Task<IActionResult> GetAsync(bool includeAuthor, [FromRoute] int skip = 0, [FromRoute] int take = 0)
        {
            var query = new GetAllBooksQuery(includeAuthor, skip, take);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        [Route("insert-new-book")]
        public async Task<IActionResult> InsertBookAsync([FromBody] CreateBookRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpPut]
        [Route("update-book")]
        public async Task<IActionResult> UpdateBookAsync([FromBody] UpdateBookRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete]
        [Route("delete-book")]
        public async Task<IActionResult> DeleteBookAsync()
        {
            return BadRequest();
        }
    }
}