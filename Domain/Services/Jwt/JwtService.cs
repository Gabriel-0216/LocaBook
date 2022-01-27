using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Commands.Requests;
using Domain.Commands.Response;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Domain.Services.Jwt;

public class JwtService : IJWTService
{
    private readonly JwtConfig _jwtConfig;
    public JwtService(IOptionsMonitor<JwtConfig> optionsMonitor)
    {
        _jwtConfig = optionsMonitor.CurrentValue;
    }
    public JwtToken GenerateTokenRegister(CreateUserResponse command)
    {
        return new JwtToken(GenerateToken(command.Id, command.Email, command.UserName), DateTime.UtcNow.AddHours(6));
    }
    public JwtToken GenerateTokenLogin(UserLoginResponse command)
    {
        return new JwtToken(GenerateToken(command.Id, command.Email, command.UserName), DateTime.UtcNow.AddHours(6));
    }
    private string GenerateToken(int id, string email, string userName)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            }),
            Expires = DateTime.UtcNow.AddHours(6),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = jwtTokenHandler.WriteToken(token);
        return jwtToken;
    }
}