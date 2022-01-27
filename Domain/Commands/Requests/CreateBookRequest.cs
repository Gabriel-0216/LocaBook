using Domain.Commands.Response;
using MediatR;
namespace Domain.Commands.Requests
{
    public class CreateBookRequest : IRequest<CreateBookResponse>
    {
        public string Title { get; set; } = string.Empty;
        public string Resume { get; set; } = string.Empty;
        public int AuthorId { get; set; }
    }
}
