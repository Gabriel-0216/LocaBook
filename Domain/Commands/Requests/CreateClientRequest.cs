using Domain.Commands.Response;
using MediatR;

namespace Domain.Commands.Requests
{
    public class CreateClientRequest : IRequest<CreateClientResponse>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cellphone { get; set; } = string.Empty;
    }
}
