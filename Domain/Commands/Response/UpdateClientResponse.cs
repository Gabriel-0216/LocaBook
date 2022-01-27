namespace Domain.Commands.Response;
public class UpdateClientResponse : Response
{

    public void SetSuccess(int id, string firstName, string lastName, string email, string cellphone)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Cellphone = cellphone;
        base.SetSuccess();
    }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Cellphone { get; private set; } = string.Empty;
}