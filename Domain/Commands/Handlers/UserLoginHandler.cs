using Domain.Commands.Requests;
using Domain.Commands.Response;
using Domain.Services.Jwt;
using Domain.Services.Password;
using Infra.Models;
using Infra.Repository.Users;
using MediatR;

namespace Domain.Commands.Handlers;

public class UserLoginHandler : IRequestHandler<UserLoginCommand, UserLoginResponse>
{
    private readonly IUserRepository _user;
    private readonly IPasswordEncrypt _password;
    private readonly IJWTService _jwt;

    public UserLoginHandler(IUserRepository user, IPasswordEncrypt password, IJWTService jwt)
    {
        _user = user;
        _password = password;
        _jwt = jwt;
    }

    public async Task<UserLoginResponse> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var response = new UserLoginResponse();
        var loginResponse = await _user.Login(new User()
        {
            Email = request.Email,
            PasswordHash = _password.Encrypt(request.Password),
        });
        if (loginResponse == null)
        {
            response.Errors.Add("Login unsuccessful");
            return response;
        }
        response.SetSuccess(loginResponse.Id, loginResponse.UserName, loginResponse.Email);
        var token = _jwt.GenerateTokenLogin(response);
        if (string.IsNullOrWhiteSpace(token.Token))
        {
            response.SetInternalError();
            return response;
        }
        response.SetToken(token);
        return response;

    }
}