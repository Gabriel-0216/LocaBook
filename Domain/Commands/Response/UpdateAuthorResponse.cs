namespace Domain.Commands.Response
{
    public class UpdateAuthorResponse : Response
    {
        public void SetSuccess(int id, string firstName, string lastName)
        {
            base.SetSuccess();
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
