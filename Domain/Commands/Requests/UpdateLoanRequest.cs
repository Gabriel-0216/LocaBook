using Domain.Commands.Response;
using MediatR;

namespace Domain.Commands.Requests;

public class UpdateLoanRequest : IRequest<UpdateLoanResponse>
{
    public int LoanId { get; set; }
    public bool FinishedStatus { get; set; }
}