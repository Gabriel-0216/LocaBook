using Domain.Queries.Query;
using Infra.Models;
using Infra.Repository;
using MediatR;
namespace Domain.Queries.Handlers
{
    public class GetUnfinishedLoansHandler : IRequestHandler<GetUnfinishedLoanQuery, IEnumerable<Loan>>
    {
        private readonly ILoanRepository _loanRepo;
        
        public GetUnfinishedLoansHandler(ILoanRepository loanRepo)
        {
            _loanRepo = loanRepo;
        }
        public async Task<IEnumerable<Loan>> Handle(GetUnfinishedLoanQuery request, CancellationToken cancellationToken)
        {
            return await _loanRepo.GetUnfinishedLoans(request.IncludeBooks, request.IncludeClient,
                request.Skip, request.Take);
        }
    }
}