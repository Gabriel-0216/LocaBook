using Domain.Commands.Requests;
using Domain.Commands.Response;

namespace Domain.Services.Jwt;

public interface IJWTService
{
    JwtToken GenerateTokenRegister(CreateUserResponse command);
    JwtToken GenerateTokenLogin(UserLoginResponse command);
}