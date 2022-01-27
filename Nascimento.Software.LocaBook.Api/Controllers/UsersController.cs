using Domain.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Nascimento.Software.LocaBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("user-login")]
        public async Task<IActionResult> UserLoginAsync([FromBody] UserLoginCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost]
        [Route("User-Registration")]
        public async Task<IActionResult> UserRegisterAsync([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}