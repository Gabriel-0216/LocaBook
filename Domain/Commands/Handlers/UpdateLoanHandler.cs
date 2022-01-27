using Domain.Commands.Requests;
using Domain.Commands.Response;
using Infra.Repository;
using MediatR;

namespace Domain.Commands.Handlers;

public class UpdateLoanHandler : IRequestHandler<UpdateLoanRequest, UpdateLoanResponse>
{
    private readonly ILoanRepository _loan;

    public UpdateLoanHandler(ILoanRepository loan)
    {
        _loan = loan;
    }

    public async Task<UpdateLoanResponse> Handle(UpdateLoanRequest request, CancellationToken cancellationToken)
    {
        var response = new UpdateLoanResponse();
        var loan = await _loan.Get(request.LoanId);
        if (loan is null)
        {
            response.Errors.Add("This loan don't exists");
            return response;
        }

        loan.IsFinished = request.FinishedStatus;
        
        var updated = await _loan.Update(loan);
        if (updated == null)
        {
            response.SetInternalError();
            return response;
        }
        response.SetSuccess(updated.Id, updated.IsFinished);
        return response;
            
        throw new NotImplementedException();
    }
}