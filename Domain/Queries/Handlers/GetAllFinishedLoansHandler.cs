using Domain.Queries.Query;
using Infra.Models;
using Infra.Repository;
using MediatR;

namespace Domain.Queries.Handlers;

public class GetAllFinishedLoansHandler : IRequestHandler<GetAllFinishedLoansQuery, IEnumerable<Loan>>
{
    private readonly ILoanRepository _loanRepo;

    public GetAllFinishedLoansHandler(ILoanRepository loanRepo)
    {
        _loanRepo = loanRepo;
    }

    public async Task<IEnumerable<Loan>> Handle(GetAllFinishedLoansQuery request, CancellationToken cancellationToken)
    {
        return await _loanRepo.GetCompletedLoans(request.IncludeBooks, request.IncludeClient, request.Skip, request.Take);
    }
}