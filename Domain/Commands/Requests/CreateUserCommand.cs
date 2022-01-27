using Domain.Commands.Response;
using MediatR;
namespace Domain.Commands.Requests;
public class CreateUserCommand : IRequest<CreateUserResponse>
{
    public string UserName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Cellphone { get; set; } = string.Empty;
}