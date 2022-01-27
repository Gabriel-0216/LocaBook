using Infra.Models;
using MediatR;

namespace Domain.Queries.Query
{
    public class GetAllAuthorsQuery : Pagination, IRequest<IEnumerable<Author>>
    {
        public bool IncludeBooks { get; set; }

        public GetAllAuthorsQuery(bool includeBooks, int skip, int take)
        {
            IncludeBooks = includeBooks;
            Skip = skip;
            Take = take;
        }
    }
}
