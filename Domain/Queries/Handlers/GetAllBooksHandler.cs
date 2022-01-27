using Domain.Queries.Query;
using Infra.Models;
using Infra.Repository;
using MediatR;

namespace Domain.Queries.Handlers
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<Book>>
    {
        private readonly IBookRepository _repo;
        public GetAllBooksHandler(IBookRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return await _repo.Get(request.IncludeAuthor, request.Skip, request.Take);
        }
    }
}
