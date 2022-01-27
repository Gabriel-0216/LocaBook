using Domain.Commands.Response;
using Infra.Models;
using MediatR;

namespace Domain.Commands.Requests;

public class UpdateBookRequest : IRequest<UpdateBookResponse>
{
    public UpdateBookRequest(int id, string title, string resume, int authorId)
    {
        Id = id;
        Title = title;
        Resume = resume;
        AuthorId = authorId;
    }

    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Resume { get; set; } = string.Empty;
    public int AuthorId { get; set; }
}