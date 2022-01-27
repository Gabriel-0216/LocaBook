using Infra.Models;
using MediatR;
namespace Domain.Queries.Query
{
    public class GetAllBooksQuery : Pagination, IRequest<IEnumerable<Book>>
    {
        public bool IncludeAuthor { get; private set; }
        public GetAllBooksQuery(bool includeAuthor, int skip, int take)
        {
            IncludeAuthor = includeAuthor;
            Skip = skip;
            Take = take;
        }
    }
}
