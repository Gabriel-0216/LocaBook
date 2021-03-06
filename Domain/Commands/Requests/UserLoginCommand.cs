using Domain.Commands.Response;
using MediatR;

namespace Domain.Commands.Requests;

public class UserLoginCommand : IRequest<UserLoginResponse>
{
    public UserLoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}