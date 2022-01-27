using Domain.Commands.Response;
using MediatR;

namespace Domain.Commands.Requests
{
    public class UpdateAuthorRequest : IRequest<UpdateAuthorResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

    }
}
