using Domain.Commands.Response;
using MediatR;
namespace Domain.Commands.Requests
{
    public class CreateAuthorRequest : IRequest<CreateAuthorResponse>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
