using Infra.Models;
using MediatR;
namespace Domain.Queries.Query
{
    public class GetUnfinishedLoanQuery : Pagination, IRequest<IEnumerable<Loan>>
    {
        public bool IncludeBooks { get; set; }
        public bool IncludeClient { get; set; }
        public GetUnfinishedLoanQuery(bool includeBooks, bool includeClientDetails, int skip, int take)
        {
            IncludeBooks = includeBooks;
            IncludeClient = includeClientDetails;
            Skip = skip;
            Take = take;
        }
    }
}
