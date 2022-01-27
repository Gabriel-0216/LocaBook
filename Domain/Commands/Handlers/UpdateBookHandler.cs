using Domain.Commands.Requests;
using Domain.Commands.Response;
using Infra.Repository;
using MediatR;

namespace Domain.Commands.Handlers;

public class UpdateBookHandler : IRequestHandler<UpdateBookRequest, UpdateBookResponse>
{
    private readonly IBookRepository _book;
    private readonly IAuthorRepository _author;

    public UpdateBookHandler(IBookRepository book, IAuthorRepository author)
    {
        _book = book;
        _author = author;
    }

    public async Task<UpdateBookResponse> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
    {
        var response = new UpdateBookResponse();
        if (string.IsNullOrWhiteSpace(request.Title)) response.Errors.Add("book title cannot be empty or null");
        if (string.IsNullOrWhiteSpace(request.Resume)) response.Errors.Add("book resume cannot be empty or null");

        if (response.Errors.Count > 0) return response;

        var bookExists = await _book.Get(request.Id);
        if (bookExists is null)
        {
            response.Errors.Add("This book don't exists");
            return response;
        }

        if (await _author.Get(request.AuthorId) is null)
        {
            response.Errors.Add("This author don't exists");
            return response;
        }

        bookExists.Title = request.Title;
        bookExists.Resume = request.Resume;
        bookExists.AuthorId = request.AuthorId;
        var updated = await _book.Update(bookExists);
        if(updated != null)
        {
            response.SetSuccess(updated.Id, updated.Title, updated.Resume, updated.CreateDate, updated.AuthorId);
            return response;
        }
        response.SetInternalError();
        return response;
    }
}