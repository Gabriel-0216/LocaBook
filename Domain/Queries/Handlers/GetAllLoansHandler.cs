using Domain.Queries.Query;
using Infra.Models;
using Infra.Repository;
using MediatR;

namespace Domain.Queries.Handlers
{
    public class GetAllLoansHandler : IRequestHandler<GetAllLoansQuery, IEnumerable<Loan>>
    {
        private readonly ILoanRepository _repo;

        public GetAllLoansHandler(ILoanRepository repo)
        {
            _repo = repo;
        }
        
        public async Task<IEnumerable<Loan>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            return await _repo.Get(request.IncludeBooks, request.IncludeClient, request.Skip, request.Take);
        }
    }
}