using Domain.Commands.Requests;
using Domain.Commands.Response;
using Domain.Services.Jwt;
using Domain.Services.Password;
using Infra.Models;
using Infra.Repository.Users;
using MediatR;

namespace Domain.Commands.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly IUserRepository _user;
    private readonly IJWTService _jwtService;
    private readonly IPasswordEncrypt _password;
    public CreateUserHandler(IJWTService jwtService, IUserRepository user, IPasswordEncrypt password)
    {
        _jwtService = jwtService;
        _user = user;
        _password = password;
    }
    public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateUserResponse();
        if(string.IsNullOrWhiteSpace(request.FirstName)) response.Errors.Add("First name can't be empty");
        if(string.IsNullOrWhiteSpace(request.LastName)) response.Errors.Add("Last name can't be empty");
        if(string.IsNullOrWhiteSpace(request.Email)) response.Errors.Add("Email can't be empty");
        if(string.IsNullOrWhiteSpace(request.UserName)) response.Errors.Add("User Name can't be empty");
        if(string.IsNullOrWhiteSpace(request.PasswordHash)) response.Errors.Add("Password can't be empty");
        if(string.IsNullOrWhiteSpace(request.Cellphone)) response.Errors.Add("Cellphone can't be empty");

        var dataValid = await _user.CheckUniquesUser(request.Email, request.UserName, request.Cellphone);
        if (!dataValid)
        {
            response.Errors.Add("The email, username or cellphone are already in use.");
            return response;
        }
        
        var createUser = await _user.Registration(new User(request.UserName, request.FirstName,
                                                                request.LastName, request.Email,
                                                                _password.Encrypt(request.PasswordHash),
                                                                request.Cellphone));
        if (createUser == null)
        {
            response.SetInternalError();
            return response;
        }
        response.SetSuccess(createUser.Id, createUser.UserName, createUser.Email);
        var tokenGenerate = _jwtService.GenerateTokenRegister(response);
        if (string.IsNullOrWhiteSpace(tokenGenerate.Token))
        {
            response.Errors.Add("The user registration was successful, but the token can't be generated, try login later.");
            return response;
        }
        response.SetToken(tokenGenerate);
        return response;
    }
}