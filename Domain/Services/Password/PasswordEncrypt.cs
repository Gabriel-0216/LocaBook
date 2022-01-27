using System.Text;

namespace Domain.Services.Password;

public class PasswordEncrypt : IPasswordEncrypt
{
    public string Encrypt(string password)
    {
        if (string.IsNullOrWhiteSpace(password)) throw new Exception("Can't encrypt a null string");
        return Convert.ToBase64String(Encoding.ASCII.GetBytes(password));
    }
}