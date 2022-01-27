namespace Domain.Commands.Response
{
    public class CreateAuthorResponse : Response
    {
        public void SetSuccess(int id, string firstName, string lastName)
        {
            base.SetSuccess();
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        private string FirstName { get; set; } = string.Empty;
        private string LastName { get; set; } = string.Empty;
    }
}
