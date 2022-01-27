using Domain.Services.Jwt;
namespace Domain.Commands.Response;

public class CreateUserResponse : Response
{
    public void SetSuccess(int id, string email, string userName)
    {
        base.SetSuccess();
        Id = id;
        Email = email;
        UserName = userName;
    }
    public void SetToken(JwtToken token)
    {
        Token = token;
    }
    public string Email { get; set; }
    public string UserName { get; set; }
    public JwtToken Token { get; set; }
}