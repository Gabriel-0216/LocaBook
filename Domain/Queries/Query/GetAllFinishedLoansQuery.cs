using Infra.Models;
using MediatR;

namespace Domain.Queries.Query;
public class GetAllFinishedLoansQuery : Pagination, IRequest<IEnumerable<Loan>>
{
    public GetAllFinishedLoansQuery(bool includeBooks, bool includeClientDetails, int skip, int take)
    {
        this.IncludeBooks = includeBooks;
        IncludeClient = includeClientDetails;
        Skip = skip;
        Take = take;
    }

    public bool IncludeClient { get; set; }
    public bool IncludeBooks { get; set; }
    
}