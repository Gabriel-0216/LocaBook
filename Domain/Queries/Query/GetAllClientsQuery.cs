using Infra.Models;
using MediatR;
namespace Domain.Queries.Query
{
    public class GetAllClientsQuery : Pagination, IRequest<IEnumerable<Client>>
    {
        public bool IncludeLoans { get; set; }
        public bool ActiveLoans { get; set; }

        public GetAllClientsQuery(bool includeLoans, bool activeLoans, int skip, int take)
        {
            IncludeLoans = includeLoans;
            ActiveLoans = activeLoans;
            Skip = skip;
            Take = take;
        }
    }
}
