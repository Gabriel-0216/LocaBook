using Infra.Models;
using MediatR;
namespace Domain.Queries.Query
{
    public class GetAllLoansQuery : Pagination, IRequest<IEnumerable<Loan>>
    {
        public bool IncludeBooks { get; set; }
        public bool IncludeClient { get; set; }
        public GetAllLoansQuery(bool includeBooks, bool includeClient, int skip, int take)
        {
            IncludeBooks = includeBooks;
            IncludeClient = includeClient;
            Skip = skip;
            Take = take;
        }
    }
}