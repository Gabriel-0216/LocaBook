using Domain.Services.Jwt;

namespace Domain.Commands.Response;

public class UserLoginResponse : Response
{
    public void SetSuccess(int id, string userName, string email)
    {
        base.SetSuccess();
        Id = id;
        UserName = userName;
        Email = email;
    }
    public void SetToken(JwtToken token)
    {
        Token = token;
    }
    public string UserName { get; set; }= string.Empty;
    public string Email { get; set; } = string.Empty;
    public JwtToken? Token { get; set; }
}