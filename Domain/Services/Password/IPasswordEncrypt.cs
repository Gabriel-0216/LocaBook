namespace Domain.Services.Password;

public interface IPasswordEncrypt
{
    string Encrypt(string password);
    
}