namespace Domain.Services.Jwt;

public class JwtToken
{
    public JwtToken(string token, DateTime valid)
    {
        Token = token;
        ExpireDateTime = valid;
    }
    public string Token { get; set; } = string.Empty;
    public DateTime ExpireDateTime { get; set; }
}