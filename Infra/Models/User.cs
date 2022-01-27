namespace Infra.Models;
public class User : Entity
{
    public User()
    { }
    public User(string username, string firstname, string lastname, string email, string password, string cellphone)
    {
        UserName = username;
        FirstName = firstname;
        LastName = lastname;
        Email = email;
        PasswordHash = password;
        Cellphone = cellphone;
    }
    public string UserName { get; set; } = string.Empty;
    public string FirstName { get; set; }= string.Empty;
    public string LastName { get; set; }= string.Empty;
    public string Email { get; set; }= string.Empty;
    public string PasswordHash { get; set; }= string.Empty;
    public string Cellphone { get; set; }= string.Empty;
}